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
    public class ItemgroupController : Controller
    {
        #region Declarations

        private LoggerProvider _loggerProvider;
        private readonly IitemService _ItemService;
        private readonly IitemgroupService _itemgroupService;
        #endregion

        #region Constructor
        public ItemgroupController(LoggerProvider loggerProvider, IitemService itemService, IitemgroupService itemgroupService)
        {
            _loggerProvider = loggerProvider;
            _ItemService = itemService;
            _itemgroupService = itemgroupService;
        }

        #endregion

        #region  Crud Methods
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Create ItemGroup
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            try
            {
                ViewBag.ItemList = new SelectList((IList)_ItemService.GetAllItems().Data, "Id", "ItemName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View("ManageItemGroup", new AddItemgroupsModel());


        }
        /// <summary>
        /// To add or insert ItemGroup
        /// </summary>
        /// <param name="itemgroupVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateItemGroup(AddItemgroupsModel itemgroupVM)
        {
            try
            {
                AddItemgroupsModel itemgroupModel = new AddItemgroupsModel();


            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return Json(_itemgroupService.AddOrUpdateItemGroup(itemgroupVM));

        }
        /// <summary>
        /// Delete ItemGroup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteItemGroup(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _itemgroupService.DeleteItemGroup(id);
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
        /// Get All ItemGroup List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllItemGroup(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _itemgroupService.GetItemGroupList(filter);
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
                ViewBag.ItemList = new SelectList((IList)_ItemService.GetAllItems().Data, "Id", "ItemName");

            }

            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View("ManageItemGroup", _itemgroupService.GetItemGroup(id));

        }

        #endregion
    }
}
