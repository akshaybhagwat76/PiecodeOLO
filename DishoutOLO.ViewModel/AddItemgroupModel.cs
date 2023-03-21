

using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddItemgroupsModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }

        public int ItemId { get; set; }
        [DisplayName("Item")]

        public string ItemName { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }

    public class UpdateItemgroupsModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }
        public bool IsActive { get; set; }
        public string ItemName { get; set; }

        public int ItemId { get; set; }

        public int DisplayOrder { get; set; }
    }

    public class ListItemgroupsModel
    {
        public int Id { get; set; }

        public string ItemGroup { get; set; }

        public int ItemId { get; set; }
        [DisplayName("Item")]

        public string ItemName { get; set; }

        public bool IsActive { get; set; }  
        public int DisplayOrder { get; set; }
    }


    public class DeleteItemgroupsModel
    {
        public int Id { get; set; }
    }
}
