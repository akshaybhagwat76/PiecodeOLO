using DishoutOLO.Data;
using DishoutOLO.Helpers.Provider;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace DishoutOLO.Controllers
{

    public class MenuController : Controller
    {
        #region Declarations
        private readonly IMenuService _menuService;
        private IRepository<MenuAvailabilities> _menuAvailabilitiesRepository;
        private readonly IMenuAvailabilityService _menuAvailabilityService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProgramService _programService;   
        
        private readonly ILogger _logger;
        private LoggerProvider _loggerProvider;
        #endregion

        #region Constructor

        public MenuController(IMenuService menuService, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment,LoggerProvider loggerProvider, IProgramService programService,IRepository<MenuAvailabilities> repository, IMenuAvailabilityService menuAvailabilityService)
        {
            _categoryService = categoryService;
            _menuService = menuService;
            _programService = programService;   
            _hostingEnvironment = hostingEnvironment;
            _loggerProvider= loggerProvider;
            _menuAvailabilityService = menuAvailabilityService; 
            _menuAvailabilitiesRepository = repository; 
        }

        #endregion

        #region Get Methods
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Create Menu
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            try
            {
                ViewBag.CategoryList = new SelectList((IList)_categoryService.GetAllCategories().Data, "Id", "CategoryName");
                ViewBag.ProgramList = new SelectList((IList)_programService.GetAllPrograms().Data, "Id", "ProgramName");
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageMenu", new AddMenuModel());
        }

        /// <summary>
        /// Get All Menu List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllMenu(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _menuService.GetMenuList(filter);
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
                ViewBag.CategoryList = new SelectList((IList)_categoryService.GetAllCategories().Data, "Id", "CategoryName");
                ViewBag.ProgramList = new SelectList((IList)_programService.GetAllPrograms().Data, "Id", "ProgramName");
                                                          
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageMenu", _menuService.GetMenu(id));
            }
        #endregion

        #region Crud Methods
        /// <summary>
        /// To add or insert menu
        /// </summary>
        /// <param name="menuVM"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateMenu(AddMenuModel menuVM)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(_menuService.AddOrUpdateMenu(menuVM));

        }

        


        /// <summary>
        /// Delete Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteMenu(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _menuService.DeleteMenu(id);
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
