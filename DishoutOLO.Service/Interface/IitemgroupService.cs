

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IitemgroupService
    {
        public DishoutOLOResponseModel AddOrUpdateItemGroup(AddItemgroupsModel data);
        public DishoutOLOResponseModel DeleteItemGroup(int data);
        public DishoutOLOResponseModel GetAllItems();
        public DataTableFilterModel GetItemGroupList(DataTableFilterModel filter);
        public AddItemgroupsModel GetItemGroup(int Id);
    }
}
