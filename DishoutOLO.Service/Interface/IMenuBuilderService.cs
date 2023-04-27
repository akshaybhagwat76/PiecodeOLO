using DishoutOLO.ViewModel;
namespace DishoutOLO.Service.Interface
{
    public interface IMenuBuilderService
    {
        public List<AddMenuBuilderModel> GetMenuBuilderList();
        public List<AddMenuModel> GetMenuCategoryById(int id);
    }
}
