

using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddItemgroupModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }

        public int ItemId { get; set; }
        [DisplayName("Item")]

        public string ItemName { get; set; }
        public bool IsActive { get; set; }

        public string DisplayOrder { get; set; }
    }

    public class UpdateItemgroupModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }
        public bool IsActive { get; set; }
        public string ItemName { get; set; }

        public int ItemId { get; set; }
        [DisplayName("Item")]

        public string DisplayOrder { get; set; }
    }

    public class ListItemgroupModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }

        public int ItemId { get; set; }

        public bool IsActive { get; set; }  
        public string ItemName { get; set; }    
        public string DisplayOrder { get; set; }
    }


    public class DeleteItemgroupModel
    {
        public int Id { get; set; }
    }
}
