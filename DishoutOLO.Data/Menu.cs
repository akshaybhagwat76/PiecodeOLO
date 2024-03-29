﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    [Table("Menus")]    
    public class Menu:BaseEntity
    {
        public string MenuName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int MenuPrice { get; set; }
        public string ProgramId { get; set; }
        public string Description { get; set; } 
        [NotMapped]
        public string CategoryName { get; set; }

        [NotMapped]
        public string ProgramName { get; set; }
        [NotMapped]
        public int MenuDetailId { get; set; }
        [NotMapped]
        public string ItemId { get; set; }
        [NotMapped]
        public int? MenuId { get; set; }
    }
}
