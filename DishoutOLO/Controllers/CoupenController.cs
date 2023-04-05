using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel.Helper;
using DishoutOLO.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class CoupenController : Controller
    {
        #region Declarations
        private readonly ICoupenService _coupenService;
        private LoggerProvider _loggerProvider;
        #endregion

        #region Constructor
        public CoupenController(ICoupenService coupenService, LoggerProvider loggerProvider)
        {
            _coupenService = coupenService;
            _loggerProvider = loggerProvider;
        }
        #endregion

        #region Get Methods
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Create Coupen
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View("ManageCoupen", new AddCoupenModel());
        }
        /// <summary>
        /// Get All Coupen List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllCoupen(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _coupenService.GetCoupenList(filter);
                return Json(list);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(filter);
        }
        /// <summary>
        /// go to edit page with update data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageCoupen", _coupenService.GetCoupen(id));
        }
        #endregion

        #region Crud Methods
        /// <summary>
        ///  To add or insert Coupen
        /// </summary>
        /// <param name="coupenVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateCoupen(AddCoupenModel coupenVM)
        {
            try
            {
                return Json(_coupenService.AddOrUpdateCoupen(coupenVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(coupenVM);
        }
        /// <summary>
        /// Delete Coupen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteCoupen(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _coupenService.DeleteCoupen(id);
                return Json(list);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return Json(id);
        }
        #endregion
    }
}
