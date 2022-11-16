//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using System.IO;
using System;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public object GetWeatherForecast(string city)
        {
            Console.WriteLine(city);
            var client = new RestClient("http://example.com");
            var request = new RestRequest(consts.AutocompleteUrl);
            request.AddParameter("apikey", consts.AccuWeatherKey);
            request.AddParameter("q", city);
            var response = client.Execute(request);
            var content = response.Result;
            return content;
            //var getWeather = JsonConvert.DeserializeObject<GetWeather>(content.Content);
            //    if (getWeather != null) { 
            //object res = new { Key =getWeather.Key, LocalizedName = getWeather.LocalizedName  };
            //return res;
            //}
            //return city;
        }

        [HttpGet]
        public object GetWeatherByCity(int key)
        {
            var result = DBConnection.GetCurrentWeatherFromAccuWeathe(key);
            if (result != null)
                return (IRestResponse)result;
            var client = new RestClient("http://example.com");
            var request = new RestRequest($"{consts.WeatherUrl}/{key}");
            request.AddParameter("apikey", consts.AccuWeatherKey);
            var response = client.Execute(request);
            var content =  response.Result;
            var weatherByCity = JsonConvert.DeserializeObject<WeatherByCity>(content.Content);
            object res = new { Key = key, Weather = weatherByCity.WeatherText, Temperature = weatherByCity.WeatherIcon };
            DBConnection.SaveCityInDB(key,weatherByCity.WeatherIcon, weatherByCity.WeatherText);
            return res;

        }

        [HttpPost]
        public ObjectResult CheckFavorite(int key)
        {
            bool answer = DBConnection.CheckFavorite(key);
            return Ok(answer);
        }

        [HttpPost]
        public ObjectResult SaveFavorite(int key, string name)
        {
            bool answer = DBConnection.AddFavorite(key, name);
            return Ok(answer);
        }

        [HttpPost]
        public ObjectResult DeleteFavorite(int key)
        {
            bool answer = DBConnection.DeleteFavotite(key);
            return Ok(answer);
        }
    }
}