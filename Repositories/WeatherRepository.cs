using SolarMonitorProject.Models;


namespace SolarMonitorProject.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ApplicationDbContext _context;

        public WeatherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherData> GetAll() => _context.WeatherData.ToList();

        public WeatherData GetById(int id) => _context.WeatherData.Find(id);

        public void Add(WeatherData data)
        {
            _context.WeatherData.Add(data);
            _context.SaveChanges();
        }

        public void Update(WeatherData data)
        {
            _context.WeatherData.Update(data);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.WeatherData.Find(id);
            if (data != null)
            {
                _context.WeatherData.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}

