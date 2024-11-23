using Microsoft.AspNetCore.Mvc;
using SolarMonitorProject.Models;
using SolarMonitorProject.Repositories;

namespace SolarMonitorProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var weatherData = _weatherRepository.GetAll();
            return Ok(weatherData);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var weatherData = _weatherRepository.GetById(id);
            if (weatherData == null)
                return NotFound();

            return Ok(weatherData);
        }

        [HttpPost]
        public IActionResult Create([FromBody] WeatherData newWeatherData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _weatherRepository.Add(newWeatherData);
            return CreatedAtAction(nameof(GetById), new { id = newWeatherData.Id }, newWeatherData);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WeatherData updatedWeatherData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingData = _weatherRepository.GetById(id);
            if (existingData == null)
                return NotFound();

            updatedWeatherData.Id = id;
            _weatherRepository.Update(updatedWeatherData);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingData = _weatherRepository.GetById(id);
            if (existingData == null)
                return NotFound();

            _weatherRepository.Delete(id);
            return NoContent();
        }
    }
}
