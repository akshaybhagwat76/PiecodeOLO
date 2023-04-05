using DishoutOLO.ViewModel.Helper;
using DishoutOLO.ViewModel;

namespace DishoutOLO.Service.Interface
{
    public interface ICoupenService
    {
        public DishoutOLOResponseModel AddOrUpdateCoupen(AddCoupenModel data);

        public DishoutOLOResponseModel DeleteCoupen(int data);
        public DataTableFilterModel GetCoupenList(DataTableFilterModel filter);
        public AddCoupenModel GetCoupen(int Id);

    }
}
