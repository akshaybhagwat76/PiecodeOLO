

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IRolesService
    {
        public DishoutOLOResponseModel AddOrUpdateRoles(AddRolesModel data);
        public DishoutOLOResponseModel DeleteRoles(int data);

        public DataTableFilterModel GetRolesList(DataTableFilterModel filter);
        public AddRolesModel GetRoles(int Id);
        public DishoutOLOResponseModel GetAllRoles();




    }
}
