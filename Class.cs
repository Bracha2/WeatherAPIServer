using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WeatherAPI
{
    public class DBConnection
    {
        public static Models.WeatherByCity? GetCurrentWeatherFromAccuWeathe(int key)
        {
            using (Models.dbContxt context = new Models.dbContxt())
            {
                Models.WeatherByCity item = (Models.WeatherByCity)context.WeatherByCities.FirstOrDefault(obj => obj.Key == key);
                return item;
            }
        }

        public static bool SaveCityInDB(int key,  int temp, string description)
        {
            using (Models.dbContxt context = new Models.dbContxt())
            {
                Models.WeatherByCity entity = new Models.WeatherByCity
                {
                    Key = key,
                    Temperature = temp,
                    Weather = description
                };
                context.WeatherByCities.Add(entity);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
              
            }
        }

        public static bool CheckFavorite(int key)
        {
            using (Models.dbContxt context = new Models.dbContxt())
            {
                Models.Favory? entity = context.Favories.FirstOrDefault(f => f.Key == key);
                if (entity != null)
                        return true;
                  return false;
            }
        }

        public static bool AddFavorite(int key, string name)
        {
            using (Models.dbContxt context = new Models.dbContxt())
            {
                Models.Favory entity = new Models.Favory
                {
                    Key = key,
                    LocalizName = name
                };
                context.Favories.Add(entity);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool DeleteFavotite(int key)
        {
            using (Models.dbContxt context = new Models.dbContxt())
            {
                Models.Favory? entity = context.Favories.FirstOrDefault(f => f.Key == key);
                if (entity != null)
                {
                    context.Favories.Remove(entity);

                    try
                    {
                        context.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

    }
}
