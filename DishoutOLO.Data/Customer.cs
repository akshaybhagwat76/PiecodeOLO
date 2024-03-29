﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    [Table("Customer")]
    public class Customer:BaseEntity
    {

       public string FirstName { get; set; }    
       public string LastName { get; set; } 

       public string Address1 { get; set; }
       public string Address2 { get; set; }
       public string Email { get; set; }    
       public string Phone { get; set; }    
    }
}
