using DishoutOLO.Data;
using DishoutOLO.Helpers.Provider;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
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
        private readonly ICategoryService _categoryService;   
        private readonly IMenuBuilderService _menubuilderService;
        private LoggerProvider _loggerProvider;


        public MenuBuilderController(IitemService itemService, IMenuBuilderService menubuilderService, LoggerProvider loggerProvider,IMenuService menuService,ICategoryService categoryService)
        {
            _itemService = itemService;
            _menuService = menuService; 
            _menubuilderService = menubuilderService;
            _loggerProvider = loggerProvider;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {

            ViewData["menuInfolist"] = _menubuilderService.GetMenuBuilderList();
            ViewBag.lstItems = (IList)_itemService.GetAllItems().Data;
            ViewBag.lstcategory = (IList)_categoryService.GetAllCategories().Data;     
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
                var list = _menubuilderService.GetMenuBuilderList();
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
