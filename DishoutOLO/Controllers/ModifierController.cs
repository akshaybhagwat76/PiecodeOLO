using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class ModifierController : Controller
    {
        #region Declarations

        private readonly IModifierService _modifierService;
        private LoggerProvider _loggerProvider;

        #endregion

        #region Constructor
        public ModifierController(IModifierService modifierService, LoggerProvider loggerProvider)
        {
            _modifierService = modifierService;
            _loggerProvider = loggerProvider;
        }

        #endregion



        #region Crud Methods
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Create Modifier
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            return View("ManageModifier", new AddModifierModel());
        }
        /// <summary>
        /// To add or insert Modifier
        /// </summary>
        /// <param name="modifierVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateModifier(AddModifierModel modifierVM)
        {
            try
            {
                return Json(_modifierService.AddOrUpdateModifier(modifierVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(modifierVM);
        }

        /// <summary>
        /// Delete Modifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteModifier(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _modifierService.DeleteModifier(id);
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
        /// Get All Modifier List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllModifier(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _modifierService.GetModifierList(filter);
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
            return View("ManageModifier", _modifierService.GetModifier(id));
        }

        #endregion

    }
}
