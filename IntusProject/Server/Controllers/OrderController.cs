using AutoMapper;
using IntusProject.Shared;
using IntusService;
using Microsoft.AspNetCore.Mvc;

namespace IntusProject.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IDataService dataService, IMapper mapper)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<IList<Order>> GetAll()
        {
            var data = await _dataService.GetAllOrders();
            return _mapper.Map<List<Order>>(data);
        }

        [Route("{orderId}")]
        [HttpGet]
        public async Task<Order> GetOrderById(int orderId)
        {
            var data = await _dataService.GetOrderById(orderId);
            return _mapper.Map<Order>(data);
        }

        //[Route("")]
        //[HttpPost]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OrderController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: OrderController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: OrderController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: OrderController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: OrderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
