using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class RolesController : Controller
    {
        #region Declarations

        private readonly IRolesService _rolesService;
        private LoggerProvider _loggerProvider;

        #endregion
        #region Constructor
        public RolesController(IRolesService rolesService, LoggerProvider loggerProvider)
        {
            _rolesService = rolesService;
            _loggerProvider = loggerProvider;
        }


        #endregion

        #region Crud Methods
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            return View("ManageRoles", new AddRolesModel());
        }
        /// <summary>
        /// To add or insert Roles
        /// </summary>
        /// <param name="rolesVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateRoles(AddRolesModel rolesVM)
        {
            try
            {
                return Json(_rolesService.AddOrUpdateRoles(rolesVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(rolesVM);
        }

        /// <summary>
        /// Delete Roles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteRoles(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _rolesService.DeleteRoles(id);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(id);
        }

        #endregion

        #region Get Methods
        /// <summary>
        /// Get All Roles List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllRoles(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _rolesService.GetRolesList(filter);
                return Json(list);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(filter);
        }
        /// <summary>
        ///  go to edit page with update data 
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
            return View("ManageRoles", _rolesService.GetRoles(id));
        }

        #endregion
    }
}
