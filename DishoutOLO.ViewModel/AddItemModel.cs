using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DishoutOLO.ViewModel
{
    public class AddItemModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [DisplayName("Category")]

        public string CategoryId { get; set; }
        public string ItemName { get; set; }


        [DisplayName("Item Image")]
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
       
        public bool IsActive { get; set; }

       public string ItemDescription { get; set; }
        public int UnitCost { get; set; }

        public int MSRP { get; set; }

        public decimal TaxRate1 { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxRate3 { get; set; }
        public decimal TaxRate4 { get; set; }

    }
    public class ListItemModel

    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [DisplayName("Category")]

        public string   CategoryId { get; set; }

        public string ItemName { get; set; }
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
      
        public bool IsActive { get; set; }
        
        public string ItemDescription { get; set; }
        public int UnitCost { get; set; }

        public int MSRP { get; set; }

        public decimal TaxRate1 { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxRate3 { get; set; }
        public decimal TaxRate4 { get; set; }


    }
    public class UpdateItemModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string CategoryId { get; set; }

        public string ItemName { get; set; }
        [Required]
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
     
        public string ItemDescription { get; set; }

        public bool IsActive { get; set; }
        public int UnitCost { get; set; }

        public int MSRP { get; set; }

        public decimal TaxRate1 { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxRate3 { get; set; }
        public decimal TaxRate4 { get; set; }
    }

    public class DeleteItemModel
    {

        public int Id { get; set; }

    }
}

