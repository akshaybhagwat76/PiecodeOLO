
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{


    public class Item : BaseEntity
    {
        
        [Required]
        [ForeignKey("ItemId")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public string    ItemName { get; set; }
        public string? ItemDescription { get; set; }

        public string ItemImage { get; set; }
        
        public int UnitCost { get; set; }

        public int  MSRP { get; set; }

        public string taxrate1 { get; set; }    
        public string taxrate2 { get; set; }
        public string taxrate3 { get; set; }
        public string taxrate4 { get; set;}
    }
 }




    

