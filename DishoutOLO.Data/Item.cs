using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DishoutOLO.Data
{
    [Table("Items")]
    public class Item : BaseEntity
    {

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public string ItemImage { get; set; }

        public int UnitCost { get; set; }

        public int MSRP { get; set; }

        public string? TaxRate1 { get; set; }
        public string? TaxRate2 { get; set; }
        public string? TaxRate3 { get; set; }
        public string? TaxRate4 { get; set; }
    }
}






