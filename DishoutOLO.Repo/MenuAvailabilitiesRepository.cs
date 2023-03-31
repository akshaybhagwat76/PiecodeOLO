using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public  class MenuAvailabilitiesRepository:Repository<MenuAvailabilities>,IMenuAvailabilitiesRepository
    {
        public MenuAvailabilitiesRepository(DishoutOLOContext dishoutOLOContext):base(dishoutOLOContext)
        {

        }
        
    }

}
