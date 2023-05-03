using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DishoutOLO.Data
{
    [Table("Items")]
    public class Item : BaseEntity
    {

       
        public string CategoryId { get; set; }
       
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public string ItemImage { get; set; }

        public int UnitCost { get; set; }

        public int MSRP { get; set; }

        public decimal TaxRate1 { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxRate3 { get; set; }
        public decimal TaxRate4 { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

    }
}






