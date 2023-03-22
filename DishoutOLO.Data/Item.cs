
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{


    public class Item : BaseEntity
    {
        public bool IsVeg { get; set; }
        [Required]
        [ForeignKey("ItemId")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public string    ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public string ItemImage { get; set; }
        public bool IsTax { get; set; }
        public string? TaxName { get; set; }
        public int TaxPercentage { get; set; }
        public bool IsCombo { get; set; }

        public string? ItemsAvailable { get; set; }
        public string? AdditionalChoices { get; set; }

        public bool? IsChooseChoices {get; set;}

        public int extraCheeseOption { get; set; }

        public int extraChickenOption { get; set; }

        public int MayonnaiseOption { get; set; }
    }

}