using AutoMapper;
using IntusProject.Shared;
using IntusService;
using IntusService.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace IntusProject.Server.Controllers
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
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataService dataService, IMapper mapper)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<SubElement>> GetAsync()
        {
            var data = await _dataService.GetAllSubElements();
            return _mapper.Map<List<SubElement>>(data);
        }
    }
}