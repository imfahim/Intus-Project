using IntusService.ServiceModel;

namespace IntusService
{
    public interface IDataService
    {
        Task<List<SubElementDTO>> GetAllSubElements();
        Task<List<WindowDTO>> GetAllWindows();
        Task<List<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int id);
        Task<WindowDTO> GetWindowsById(int id);
        Task<List<WindowDTO>> GetWindowsByOrderId(int orderId);
        Task<SubElementDTO> GetSubElementsById(int id);
        Task<List<SubElementDTO>> GetSubElementsByWindowId(int windowId);
        Task SaveSubElementsState(IList<SubElementDTO> postData, int windowId);
    }
}
