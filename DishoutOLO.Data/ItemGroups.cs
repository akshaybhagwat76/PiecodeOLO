using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DishoutOLO.Data
{
    [Table("ItemGroups")]
    public class ItemGroups : BaseEntity
    {

        public string ItemGroup { get; set; }
        [Required]
        [ForeignKey("ItemId")]
        public virtual ItemGroups ItemGroups1 { get; set; }

        public int ItemId { get; set; }
        public int DisplayOrder { get; set; }

        [NotMapped]
        public string ItemName { get; set; }
    }
}
