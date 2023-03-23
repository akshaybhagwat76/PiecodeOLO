
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IModifierGroupService
    {
        public AddModifierGroupModel GetModifierGroup(int Id);
        public DataTableFilterModel GetModifierGroupList(DataTableFilterModel filter);

        public DishoutOLOResponseModel GetAllModifier();

        public DishoutOLOResponseModel AddOrUpdateModifierGroup(AddModifierGroupModel data);
        public DishoutOLOResponseModel DeleteModifierGroup(int data);
    }
}
