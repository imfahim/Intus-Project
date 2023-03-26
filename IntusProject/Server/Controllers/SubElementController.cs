using AutoMapper;
using IntusProject.Shared;
using IntusService;
using IntusService.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace IntusProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubElementController : ControllerBase
    {
        private readonly ILogger<SubElementController> _logger;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        public SubElementController(ILogger<SubElementController> logger, IDataService dataService, IMapper mapper)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }
        [Route("")]
        [HttpGet]
        public async Task<IList<SubElement>> GetAll()
        {
            var data = await _dataService.GetAllSubElements();
            return _mapper.Map<List<SubElement>>(data);
        }
        [Route("window/{windowId}")]
        [HttpPost]
        public async Task SaveState([FromBody]IList<SubElement> postData, int windowId)
        {
            await _dataService.SaveSubElementsState(_mapper.Map<List<SubElementDTO>>(postData), windowId);
            //return _mapper.Map<List<SubElement>>(data);
        }
        [Route("{subElementId}")]
        [HttpGet]
        public async Task<SubElement> GetSubElementById(int subElementId)
        {
            var data = await _dataService.GetSubElementsById(subElementId);
            return _mapper.Map<SubElement>(data);
        }
        [Route("window/{windowId}")]
        [HttpGet]
        public async Task<IList<SubElement>> GetSubElementByWindowId(int windowId)
        {
            var data = await _dataService.GetSubElementsByWindowId(windowId);
            return _mapper.Map<List<SubElement>>(data);
        }
    }
}
