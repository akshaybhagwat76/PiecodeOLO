using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Linq;

namespace DishoutOLO.Controllers
{
    public class UserStaffController : Controller
    {
        #region Declarations

        private readonly IUserStaffService _userstaffService;
        private readonly IRolesService _rolesService;

        private LoggerProvider _loggerProvider;

        #endregion

        #region Constructor
        public UserStaffController(IUserStaffService usetstaffService, LoggerProvider loggerProvider, IRolesService rolesService)
        {
            _userstaffService = usetstaffService;
            _loggerProvider = loggerProvider;
            _rolesService = rolesService;   
        }

        #endregion

        #region Crud Methods
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Create UserStaff
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.RolesList = new SelectList((IList)_rolesService.GetAllRoles().Data, "Id", "RolesName");

            return View("ManageUserStaff", new AddUserStaffModel());
        }
        /// <summary>
        /// To add or insert UserStaff
        /// </summary>
        /// <param name="UserStaffVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateUserStaff(AddUserStaffModel UserStaffVM)
        {
            try
            {
                return Json(_userstaffService.AddOrUpdateUserStaff(UserStaffVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(UserStaffVM);
        }

        /// <summary>
        /// Delete UserStaff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteUserStaff(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _userstaffService.DeleteUserStaff(id);
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
        /// Get All UserStaff List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllUserStaff(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _userstaffService.GetUserStaffList(filter);
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
                ViewBag.RolesList = new SelectList((IList)_rolesService.GetAllRoles().Data, "Id", "RolesName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageUserStaff", _userstaffService.GetUserStaff(id));
        }

        

        #endregion
    }

        
}
