using IntusRepository.Entity;
using IntusRepository.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IntusRepository
{
    public class DataRepository : IDataRepository
    {
        private readonly DBContext _context;

        public DataRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<SubElement>> GetAllSubElements()
        {
            var res = await _context.SubElements.AsNoTracking().ToListAsync();
            return res;
        }
        public async Task<SubElement> GetSubElementsById(int id)
        {
            var res = await _context.SubElements.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            return res;
        }
        public async Task<SubElement> AddSubElements(SubElement data)
        {
            _context.SubElements.Add(data);
            await SaveEntitiesAsync();
            return data;
        }
        public async Task<SubElement> UpdateSubElements(SubElement data)
        {
            var subElement = await _context.SubElements.FindAsync(data.Id);
            if(subElement == null)
            {
                throw new Exception("Not Found");
            }
            subElement.Element = data.Element;
            subElement.Type = data.Type;
            subElement.Width = data.Width;
            subElement.Height = data.Height;
            subElement.UpdatedOn = DateTime.UtcNow;
            await SaveEntitiesAsync();
            return subElement;
        }
        public async Task DeleteSubElements(int id)
        {
            var subElement = await _context.SubElements.FindAsync(id);
            if (subElement == null)
            {
                throw new Exception("Not Found");
            }
            _context.SubElements.Remove(subElement);
            await SaveEntitiesAsync();
        }
        public async Task<List<Window>> GetAllWindows(bool includeSubElements = false)
        {
            IQueryable<Window> query = _context.Set<Window>();
            if (includeSubElements)
                query = query.Include(x => x.SubElements);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<Window> GetWindowsById(int id)
        {
            var res = await _context.Windows.AsNoTracking().Include(x=>x.SubElements).FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        public async Task<Window> AddWindow(Window data)
        {
            _context.Windows.Add(data);
            await SaveEntitiesAsync();
            return data;
        }
        public async Task<Window> UpdateWindows(Window data)
        {
            var window = await _context.Windows.FindAsync(data.Id);
            if (window == null)
            {
                throw new Exception("Not Found");
            }
            window.Name = data.Name;
            window.QuantityOfWindows = data.QuantityOfWindows;
            window.UpdatedOn = DateTime.UtcNow;
            await SaveEntitiesAsync();
            return window;
        }
        public async Task DeleteWindow(int id)
        {
            var window = await _context.Windows.FindAsync(id);
            if (window == null)
            {
                throw new Exception("Not Found");
            }
            _context.Windows.Remove(window);
            await SaveEntitiesAsync();
        }
        public async Task<List<Order>> GetAllOrders(bool includeWindows = false)
        {
            IQueryable<Order> query = _context.Set<Order>();
            if (includeWindows)
                query = query.Include(x => x.Windows);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            var res = await _context.Orders.AsNoTracking().Include(x=>x.Windows).FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        public async Task<Order> AddOrder(Order data)
        {
            _context.Orders.Add(data);
            await SaveEntitiesAsync();
            return data;
        }
        public async Task<Order> UpdateOrder(Order data)
        {
            var order = await _context.Orders.FindAsync(data.Id);
            if (order == null)
            {
                throw new Exception("Not Found");
            }
            order.Name = data.Name;
            order.State = data.State;
            order.UpdatedOn = DateTime.UtcNow;
            await SaveEntitiesAsync();
            return order;
        }
        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new Exception("Not Found");
            }
            _context.Orders.Remove(order);
            await SaveEntitiesAsync();
        }
        private async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            int numberOfRecordsSaved = 0;
            var editedEntities = _context.ChangeTracker.Entries()
                                        .Where(entityEntry => entityEntry.State == EntityState.Modified)
                                        .ToList();
            numberOfRecordsSaved = await _context.SaveChangesAsync(cancellationToken);
            return numberOfRecordsSaved;
        }
    }
}
