

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    public class MenuAvailabilities:BaseEntity
    {

        public string utC_FromTime { get; set; }

        public string utC_ToTime { get; set; }

        [Required]
        [ForeignKey("MenuId")]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public string daysList { get; set; }


    }
}
