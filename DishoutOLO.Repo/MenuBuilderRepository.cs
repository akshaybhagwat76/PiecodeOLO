
using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class MenuBuilderRepository : Repository<MenuBuilder>, IMenuBuilderRepository
    {
        public MenuBuilderRepository(DishoutOLOContext context) : base(context)
        {
        }
    }
}