using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DependencyService1 _dependencyService1;
        private readonly DependencyService2 _dependencyService2;
        private readonly IEnumerable<IOperationSingletonInstance> _allSingletonInstances;



        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            DependencyService1 dependencyService1,
            DependencyService2 dependencyService2,
             IEnumerable<IOperationSingletonInstance> allSingletonInstances)
        {
            _dependencyService1 = dependencyService1;
            _dependencyService2 = dependencyService2;
            _allSingletonInstances = allSingletonInstances;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _dependencyService1.Write();
            _dependencyService2.Write();
            foreach (var instance in _allSingletonInstances)
                Console.WriteLine(instance.OperationId);

            return Enumerable.Empty<WeatherForecast>();
        }
    }
}
