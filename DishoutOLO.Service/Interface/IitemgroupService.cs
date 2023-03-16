

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IitemgroupService
    {
        public DishoutOLOResponseModel AddOrUpdateItemGroup(AddItemgroupModel data);
        public DishoutOLOResponseModel DeleteItemGroup(int data);
        public DishoutOLOResponseModel GetAllItems();
        public DataTableFilterModel GetItemGroupList(DataTableFilterModel filter);
        public AddItemgroupModel GetItemGroup(int Id);
    }
}
