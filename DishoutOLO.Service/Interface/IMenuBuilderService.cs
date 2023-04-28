using DishoutOLO.Data;
using DishoutOLO.ViewModel;
namespace DishoutOLO.Service.Interface
{
    public interface IMenuBuilderService
    {
        public List<AddMenuBuilderModel> GetMenuBuilderList();

        public List<Menu> GetMenuById(int id);

    }
}
