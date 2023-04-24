using DishoutOLO.Helpers.Provider;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace DishoutOLO.Controllers
{
    public class MenuBuilderController : Controller
    {

        private readonly IitemService _itemService;
        private readonly IMenuService _menuService;

        private readonly IMenuBuilderService _menubuilderService;
        private LoggerProvider _loggerProvider;


        public MenuBuilderController(IitemService itemService, IMenuBuilderService menubuilderService, LoggerProvider loggerProvider,IMenuService menuService)
        {
            _itemService = itemService;
            _menuService = menuService; 
            _menubuilderService = menubuilderService;
            _loggerProvider = loggerProvider;
        }

        public IActionResult Index()
        {

            ViewBag.ItemList = new SelectList((IList)_itemService.GetAllItems().Data, "Id", "ItemName");

            return View();
        }

        #region Get Methods
        
        /// <summary>
        /// Get All MenuBuilder List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllMenuBuilder(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _menubuilderService.GetMenuBuilderList(filter);
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
