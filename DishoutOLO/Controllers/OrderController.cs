using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class OrderController : Controller
    {
        #region Declarations
        private readonly IOrderService _orderService;
        private LoggerProvider _loggerProvider;
        #endregion

        #region Constructor
        public OrderController(IOrderService orderService, LoggerProvider loggerProvider)
        {
            _orderService = orderService;
            _loggerProvider = loggerProvider;
        }
        #endregion

        #region Get Methods
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get All Order List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllOrder(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _orderService.GetOrderList(filter);
                return Json(list);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(filter);
        }

        #endregion



















    }
}
