using DishoutOLO.Data;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IMenuBuilderService
    {
        public List<AddMenuBuilderModel> GetMenuBuilderList();

        public List<Menu> GetMenuById(int id);

    }
}
