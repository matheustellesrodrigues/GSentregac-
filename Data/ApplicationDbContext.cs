using Microsoft.EntityFrameworkCore;
using SolarMonitorProject.Models;

namespace SolarMonitorProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WeatherData> WeatherData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherData>().ToTable("WEATHER_DATA"); // Nome da tabela no banco
        }
    }
}
