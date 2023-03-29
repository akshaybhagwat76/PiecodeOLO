using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Web.Mvc;

namespace DishoutOLO.ViewModel
{
    public class AddMenuModel
    {

        public int Id { get; set; }

        [DisplayName("Menu Name")]
        public string MenuName { get; set; }

        [DisplayName("Menu Price")]
        public int MenuPrice { get; set; }
        public string CategoryName { get; set; }
        [DisplayName("Category ")]
        public int CategoryId { get; set; }
        public string ProgramName { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Program")]
        public string ProgramId { get; set; }
        public string Description { get; set; }
        public List<MenuAvaliblities> lstAval { get; set; }
        

    }
    public class MenuAvaliblities
    {
        public string endtime { get; set; }
        public string fromtime { get; set; }
        public string week { get; set; }
            
    }

    public class ListMenuModel
    {
        public int Id { get; set; }

        public string MenuName { get; set; }
        
        public string CategoryName { get; set; }
        [DisplayName("CategorY")]

        public IFormFile File { get; set; }

        public int MenuPrice { get; set; }

        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string ProgramName { get; set; }
        [DisplayName("Program")]

        public bool IsActive { get; set; }
        public string ProgramId { get; set; }
        public string Description { get; set; }

    }

    public class UpdateMenuModel
    {
        public int Id { get; set; }

        public string MenuName { get; set; }
        public IFormFile File { get; set; }

        public int MenuPrice { get; set; }
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public string Image { get; set; }

        public string ProgramId { get; set; }

        public string Description { get; set; }
        public string ProgramName { get; set; }
       

    }

    public class DeleteMenuModel
    {
        public int Id { get; set;    }
    }

}
