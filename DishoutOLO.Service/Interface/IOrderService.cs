

using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IOrderService
    {
        public DataTableFilterModel GetOrderList(DataTableFilterModel filter);

    }
}
