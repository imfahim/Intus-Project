using AutoMapper;
using IntusRepository;
using IntusRepository.Entity;
using IntusService.ServiceModel;

namespace IntusService
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _repo;
        private readonly IMapper _mapper;

        public DataService(IDataRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SubElementDTO>> GetAllSubElements()
        {
            var data = await _repo.GetAllSubElements();
            if (data == null) return new List<SubElementDTO>();
            return _mapper.Map<List<SubElementDTO>>(data);
        }
        public async Task SaveSubElementsState(IList<SubElementDTO> postData, int windowId)
        {
            var newAdded = postData.Where(x => x.Id == 0).ToList();
            var allSubElements = await GetSubElementsByWindowId(windowId);
            var deleted = allSubElements.Where(x => !postData.Select(x => x.Id).Contains(x.Id)).ToList();

            foreach (var sub in newAdded) {
                await _repo.AddSubElements(_mapper.Map<SubElement>(sub));
            }
            foreach (var sub in deleted)
            {
                await _repo.DeleteSubElements(sub.Id);
            }
        }
        public async Task SaveWindowsState(IList<WindowDTO> postData, int windowId)
        {
            var newAdded = postData.Where(x => x.Id == 0).ToList();
            var allWindows = await GetWindowsByOrderId(windowId);
            var deleted = allWindows.Where(x => !postData.Select(x => x.Id).Contains(x.Id)).ToList();

            foreach (var win in newAdded)
            {
                await _repo.AddWindow(_mapper.Map<Window>(win));
            }
            foreach (var win in deleted)
            {
                var subElements = await GetSubElementsByWindowId(win.Id);
                foreach (var sub in subElements)
                {
                    await _repo.DeleteSubElements(sub.Id);
                }
                await _repo.DeleteWindow(win.Id);
            }
        }
        public async Task SaveOrdersState(IList<OrderDTO> postData, int windowId)
        {
            var newAdded = postData.Where(x => x.Id == 0).ToList();
            var allOreders = await GetAllOrders();
            var deleted = allOreders.Where(x => !postData.Select(x => x.Id).Contains(x.Id)).ToList();

            foreach (var ord in newAdded)
            {
                await _repo.AddOrder(_mapper.Map<Order>(ord));
            }
            foreach (var ord in deleted)
            {
                var windows = await GetWindowsByOrderId(ord.Id);
                foreach (var win in windows)
                {
                    var subElements = await GetSubElementsByWindowId(win.Id);
                    foreach (var sub in subElements)
                    {
                        await _repo.DeleteSubElements(sub.Id);
                    }
                    await _repo.DeleteWindow(win.Id)
               }
                await _repo.DeleteOrder(ord.Id);
            }
        }

        public async Task<List<WindowDTO>> GetAllWindows()
        {
            var data = await _repo.GetAllWindows();
            if (data == null) return new List<WindowDTO>();
            return _mapper.Map<List<WindowDTO>>(data);
        }
        public async Task<WindowDTO> GetWindowsById(int id)
        {
            var data = await _repo.GetWindowsById(id);
            if (data == null) throw new Exception("Not Found");
            return _mapper.Map<WindowDTO>(data);
        }
        public async Task<List<WindowDTO>> GetWindowsByOrderId(int orderId)
        {
            var data = await _repo.GetWindowsByOrderId(orderId);
            if(data == null) return new List<WindowDTO>();
            try
            {
                var asd = _mapper.Map<List<WindowDTO>>(data);
            }
            catch(Exception ex)
            {

            }
            return _mapper.Map<List<WindowDTO>>(data);
        }
        public async Task<SubElementDTO> GetSubElementsById(int id)
        {
            var data = await _repo.GetSubElementsById(id);
            if (data == null) throw new Exception("Not Found");
            return _mapper.Map<SubElementDTO>(data);
        }
        public async Task<List<SubElementDTO>> GetSubElementsByWindowId(int windowId)
        {
            var data = await _repo.GetSubElementsByWindow(windowId);
            if (data == null) return new List<SubElementDTO>();
            return _mapper.Map<List<SubElementDTO>>(data);
        }
        public async Task<List<OrderDTO>> GetAllOrders()
        {
            var data = await _repo.GetAllOrders();
            if (data == null) return new List<OrderDTO>();
            return _mapper.Map<List<OrderDTO>>(data);
        }
        public async Task<OrderDTO> GetOrderById(int id)
        {
            var data = await _repo.GetOrderById(id);
            if (data == null) throw new Exception("Not Found");
            return _mapper.Map<OrderDTO>(data);
        }
    }
}
