using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class RolesRepository : Repository<Roles>, IRolesRepository
    {
        public RolesRepository(DishoutOLOContext context) : base(context)
        {

        }
    }
}