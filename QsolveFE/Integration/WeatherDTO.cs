namespace QsolveFE.Integration
{
    public class WeatherDTO
    {
        public Guid id  { get; set; }
        public DateTime dateTime { get; set; }
        public double temperatureC { get; set; }
        public double temperatureF { get; set; }
        public string  summary { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
