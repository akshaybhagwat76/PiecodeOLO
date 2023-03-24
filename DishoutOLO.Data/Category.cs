﻿using System.ComponentModel.DataAnnotations.Schema;
namespace DishoutOLO.Data
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
