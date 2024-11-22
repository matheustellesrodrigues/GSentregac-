namespace SolarMonitorProject.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double SolarIntensity { get; set; }
        public string Recommendation { get; set; } = string.Empty;
    }
}
