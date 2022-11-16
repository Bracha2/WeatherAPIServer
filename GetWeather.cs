namespace WeatherAPI
{
    public class GetWeather
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public object Country { get; set; }
        public object AdministrativeArea { get; set; }
       

    }
}
