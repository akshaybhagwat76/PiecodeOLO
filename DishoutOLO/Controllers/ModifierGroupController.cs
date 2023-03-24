using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace DishoutOLO.Controllers
{
    public class ModifierGroupController : Controller
    {
        #region Declarations
        private readonly IModifierService _modifierService;
        private readonly IModifierGroupService _modifiergroupService;
        private LoggerProvider _loggerProvider;

        #endregion

        #region Constructor
        public ModifierGroupController(IModifierService modifierService, IModifierGroupService modifiergroupService, LoggerProvider loggerProvider)
        {
            _modifierService = modifierService;
            _modifiergroupService = modifiergroupService;
            _loggerProvider = loggerProvider;
        }
        #endregion


        #region Crud Methods
        public IActionResult Index()
        {
            try
            {
                _loggerProvider.logmsg("Okak");
                ViewBag.ModifierList = new SelectList((IList)_modifierService.GetAllModifier().Data, "Id", "ModifierName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View();
        }
        /// <summary>
        /// Create ModifierGroup
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            try
            {
                ViewBag.ModifierList = new SelectList((IList)_modifierService.GetAllModifier().Data, "Id", "ModifierName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View("ManageModifierGroup", new AddModifierGroupModel());
        }

        /// <summary>
        /// To add or insert ModifierGroup
        /// </summary>
        /// <param name="itemVM"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateModifierGroup(AddModifierGroupModel modifiergroupVM)
        {
            try
            {
                AddModifierGroupModel itemModel = new AddModifierGroupModel();
                              
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return Json(_modifiergroupService.AddOrUpdateModifierGroup(modifiergroupVM));

        }

        /// <summary>
        /// Delete ModifierGroup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteModifierGroup(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _modifiergroupService.DeleteModifierGroup(id);
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
        /// Get All ModifierGroup List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllModifierGroup(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _modifiergroupService.GetModifierGroupList(filter);
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
                ViewBag.ModifierList = new SelectList((IList)_modifierService.GetAllModifier().Data, "Id", "ModifierName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageModifierGroup", _modifiergroupService.GetModifierGroup(id));
        }
        #endregion
    }
}
