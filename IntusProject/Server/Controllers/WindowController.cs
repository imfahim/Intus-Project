using AutoMapper;
using IntusProject.Shared;
using IntusService;
using IntusService.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace IntusProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WindowController : ControllerBase
    {
        private readonly ILogger<WindowController> _logger;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public WindowController(ILogger<WindowController> logger, IDataService dataService, IMapper mapper)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<IList<Window>> GetAll()
        {
            var data = await _dataService.GetAllWindows();
            return _mapper.Map<List<Window>>(data);
        }
        [Route("order/{orderId}")]
        [HttpPost]
        public async Task SaveState([FromBody] IList<Window> postData, int orderId)
        {
            await _dataService.SaveWindowsState(_mapper.Map<List<WindowDTO>>(postData), orderId);
        }
        [Route("{windowId}")]
        [HttpGet]
        public async Task<Window> GetWindowById(int windowId)
        {
            var data = await _dataService.GetWindowsById(windowId);
            return _mapper.Map<Window>(data);
        }
        [Route("order/{orderId}")]
        [HttpGet]
        public async Task<IList<Window>> GetWindowsByOrderId(int orderId)
        {
            var data = await _dataService.GetWindowsByOrderId(orderId);
            return _mapper.Map<List<Window>>(data);
        }
    }
}
