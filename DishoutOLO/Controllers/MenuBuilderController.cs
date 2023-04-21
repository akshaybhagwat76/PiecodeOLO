using DishoutOLO.Helpers.Provider;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace DishoutOLO.Controllers
{
    public class MenuBuilderController : Controller
    {

        private readonly IitemService _itemService;
        public MenuBuilderController(IitemService itemService)
        {
            _itemService = itemService;


        }

        public IActionResult Index()
        {
            ViewBag.ItemList = new SelectList((IList)_itemService.GetAllItems().Data, "Id", "ItemName");

            return View();
        }
    }
}
