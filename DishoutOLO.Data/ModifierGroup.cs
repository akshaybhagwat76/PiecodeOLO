

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    public class ModifierGroup:BaseEntity
    {
        [Required]
        [ForeignKey("ModifierId")]
        public virtual Modifier Modifier { get; set; }
        public int ModifierId { get; set; }

        public int price { get; set; }

        public string ModifierGroupName { get; set; }

          
    }
}
