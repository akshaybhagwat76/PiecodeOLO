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

        public int CategoryId { get; set; }
        public string ItemName { get; set; }


        [DisplayName("Item Image")]
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
        public bool IsCombo { get; set; }
        public bool  IsVeg { get; set; }
        public bool  IsTax { get; set; }
        public bool IsActive { get; set; }

        public String TaxName { get; set; }
        public int TaxPercentage { get; set; }
        public bool IsChooseChoices { get; set; }

        public string ItemDescription { get; set; }


        public int extraCheeseOption { get; set; }

        public int extraChickenOption { get; set; }

        public int MayonnaiseOption { get; set; }





    }
    public class ListItemModel

    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [DisplayName("Category")]

        public int   CategoryId { get; set; }

        public string ItemName { get; set; }
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
        public bool  IsCombo { get; set; }
        public bool IsActive { get; set; }
        public bool   IsVeg { get; set; }
        public bool  IsTax { get; set; }

        public string ItemDescription { get; set; }
        public bool? IsChooseChoices { get; set; }


    }
    public class UpdateItemModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string ItemName { get; set; }
        [Required]
        public string ItemImage { get; set; }

        public IFormFile File { get; set; }
        public bool IsCombo { get; set; }
        public string ItemDescription { get; set; }

        public bool IsVeg { get; set; }
        public bool IsTax { get; set; }
        public bool IsActive { get; set; }
        public bool IsChooseChoices { get; set; }



    }

    public class DeleteItemModel
    {

        public int Id { get; set; }

    }
}

