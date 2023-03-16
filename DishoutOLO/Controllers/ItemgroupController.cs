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

        private LoggerProvider _loggerProvider;
        private readonly IitemService _ItemService;
        private readonly IitemgroupService _itemgroupService;

        public ItemgroupController(LoggerProvider loggerProvider, IitemService itemService, IitemgroupService itemgroupService)
        {
            _loggerProvider = loggerProvider;
            _ItemService = itemService;
            _itemgroupService = itemgroupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult Create()
        {
            try
            {
                ViewBag.ItemList = new SelectList((IList)_ItemService.GetAllItems().Data, "Id", "ItemName");

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View("ManageItemGroup", new AddItemgroupModel());

            
        }

        public JsonResult AddOrUpdateItemGroup(AddItemgroupModel itemgroupVM)
        {
            try
            {
                AddItemgroupModel itemgroupModel = new AddItemgroupModel();

               
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return Json(_itemgroupService.AddOrUpdateItemGroup(itemgroupVM));

        }

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

        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.ItemList = new SelectList((IList)_ItemService.GetAllItems().Data, "Id", "ItemName", id);

            }

            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);

            }
            return View("ManageItemGroup", _itemgroupService.GetItemGroup(id));

        }

    }
}
