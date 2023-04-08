

using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class UserStaffRepository:Repository<UserStaff>,IUserStaffRepository
    {
        public UserStaffRepository(DishoutOLOContext dishoutOLO):base (dishoutOLO)
        {
            
        }
    }
}
