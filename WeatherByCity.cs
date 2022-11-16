namespace WeatherAPI
{
    public class WeatherByCity
    {
        public DateTime LocalObservationDateTime { get; set; }
        public double EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public object Temperature { get; set; }
        public object Imperial { get; set; }

    }
}
