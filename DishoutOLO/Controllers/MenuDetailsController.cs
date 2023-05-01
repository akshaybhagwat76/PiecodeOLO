using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class MenuDetailsController : Controller
    {
        #region Declarations
        private readonly IMenuDetailsService _menudetailsService;
        private LoggerProvider _loggerProvider;
        #endregion
        #region Constructor
        public MenuDetailsController(IMenuDetailsService menudetailsService, LoggerProvider loggerProvider)
        {
            _menudetailsService = menudetailsService;
            _loggerProvider = loggerProvider;
        }
        #endregion

        #region Crud Methods
        public IActionResult Index()
        {

            return View();
        }


        /// <summary>
        /// To add or insert Article
        /// </summary>
        /// <param name="menudetailVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateMenuDetails(AddMenuDetailsModel menudetailVM)
        {
            try
            {
                return Json(_menudetailsService.AddOrUpdateMenuDetails(menudetailVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(menudetailVM);
        }

        

        #endregion
        
    }
}
