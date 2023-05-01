using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Repo.Migrations;

namespace DishoutOLO.Repo
{
    public class MenuDetailsRepository:Repository<Data.MenuDetails>, IMenuDetailsRepository
    {
        public MenuDetailsRepository(DishoutOLOContext dishoutOLO ) : base(dishoutOLO)
        {
            
        }
    }
}
