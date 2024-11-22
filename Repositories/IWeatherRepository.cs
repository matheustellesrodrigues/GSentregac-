using SolarMonitorProject.Models;

namespace SolarMonitorProject.Repositories
{
    public interface IWeatherRepository
    {
        IEnumerable<WeatherData> GetAll();
        WeatherData GetById(int id);
        void Add(WeatherData data);
        void Update(WeatherData data);
        void Delete(int id);
    }
}