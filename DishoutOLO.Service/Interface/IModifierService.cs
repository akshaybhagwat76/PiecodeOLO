

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IModifierService
    {
        public DishoutOLOResponseModel AddOrUpdateModifier(AddModifierModel data);

        public DishoutOLOResponseModel DeleteModifier(int data);
        public AddModifierModel GetModifier(int Id);
        public DishoutOLOResponseModel GetAllModifier();

        public DataTableFilterModel GetModifierList(DataTableFilterModel filter);
    }
}
