using Microsoft.AspNetCore.Mvc;
using SolarMonitorProject.Models;
using SolarMonitorProject.Repositories;
using SolarMonitorProject.Services;
using SolarMonitorProject.ML;

namespace SolarMonitorProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherMonitorController : ControllerBase
    {
        private readonly IWeatherRepository _repository;
        private readonly ModelTrainer _modelTrainer;

        public WeatherMonitorController(IWeatherRepository repository)
        {
            _repository = repository;
            _modelTrainer = new ModelTrainer();
        }

        [HttpPost("predict")]
        public IActionResult Predict(ModelInput input)
        {
            var result = _modelTrainer.Predict(input);
            return Ok(result);
        }

        [HttpPost("train")]
        public IActionResult TrainModel()
        {
            var data = _repository.GetAll()
                .Select(d => new ModelInput
                {
                    Temperature = (float)d.Temperature,
                    SolarIntensity = (float)d.SolarIntensity,
                    Recommendation = d.Recommendation
                });
            _modelTrainer.TrainModel(data);
            return Ok("Model trained successfully.");
        }
    }
}
