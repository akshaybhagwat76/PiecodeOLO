

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IUserStaffService
    {
        public DishoutOLOResponseModel AddOrUpdateUserStaff(AddUserStaffModel data);
        public DishoutOLOResponseModel DeleteUserStaff(int data);

        public DataTableFilterModel GetUserStaffList(DataTableFilterModel filter);

        public AddUserStaffModel GetUserStaff(int Id);

        public DishoutOLOResponseModel GetAllRoles();




    }
}
