using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DishoutOLO.Data
{
    [Table("ItemGroups")]
    public class ItemGroup : BaseEntity

    {

        public string itemGroup { get; set; }
        [Required]
        [ForeignKey("ItemId")]
        public virtual ItemGroup ItemGroups { get; set; }

        public int ItemId { get; set; }
        public string DisplayOrder { get; set; }
    }
}
