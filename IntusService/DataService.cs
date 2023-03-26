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
            var data = await _repo.GetOrderById(orderId);
            if (data == null) throw new Exception("Not Found");
            if(data.Windows == null) return new List<WindowDTO>();
            return _mapper.Map<List<WindowDTO>>(data.Windows);
        }
        public async Task<SubElementDTO> GetSubElementsById(int id)
        {
            var data = await _repo.GetSubElementsById(id);
            if (data == null) throw new Exception("Not Found");
            return _mapper.Map<SubElementDTO>(data);
        }
        public async Task<List<SubElementDTO>> GetSubElementsByWindowId(int windowId)
        {
            var data = await _repo.GetWindowsById(windowId);
            if (data == null) throw new Exception("Not Found");
            if (data.SubElements == null) return new List<SubElementDTO>();
            return _mapper.Map<List<SubElementDTO>>(data.SubElements);
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
