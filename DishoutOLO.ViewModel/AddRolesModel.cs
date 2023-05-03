

namespace DishoutOLO.ViewModel
{
    public class AddRolesModel
    {
        public int Id { get; set; } 
        public string RolesName { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateRolesModel
    {
        public int Id { get; set; }
        public string RolesName { get; set; }
        public bool IsActive { get; set; }

    }

    public class ListRolesModel
    {
        public int Id { get; set; }
        public string RolesName { get; set; }
        public bool IsActive { get; set; }

    }

    public class DeleteRolesModel
    {
        public int Id { get; set; }
    }
}
