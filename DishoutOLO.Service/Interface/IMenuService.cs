﻿
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
namespace DishoutOLO.Service.Interface
{
    public interface IMenuService
    {
        public DishoutOLOResponseModel AddOrUpdateMenu(AddMenuModel data);

        public DishoutOLOResponseModel DeleteMenu(int data);
        public AddMenuModel GetMenu(int Id);

        public DataTableFilterModel GetMenuList(DataTableFilterModel filter);

       
    }
}
