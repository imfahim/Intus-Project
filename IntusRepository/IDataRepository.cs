using IntusRepository.Entity;

namespace IntusRepository
{
    public interface IDataRepository
    {
        Task<List<SubElement>> GetAllSubElements();
        Task<SubElement> GetSubElementsById(int id);
        Task<List<SubElement>> GetSubElementsByWindow(int id);
        Task<SubElement> AddSubElements(SubElement data);
        Task<SubElement> UpdateSubElements(SubElement data);
        Task DeleteSubElements(int id);
        Task<List<Window>> GetAllWindows(bool includeSubElements = false);
        Task<Window> GetWindowsById(int id);
        Task<List<Window>> GetWindowsByOrderId(int id);
        Task<Window> AddWindow(Window data);
        Task<Window> UpdateWindows(Window data);
        Task DeleteWindow(int id);
        Task<List<Order>> GetAllOrders(bool includeWindows = false);
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrder(Order data);
        Task<Order> UpdateOrder(Order data);
        Task DeleteOrder(int id);

    }
}
