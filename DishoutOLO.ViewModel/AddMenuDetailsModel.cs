 
namespace DishoutOLO.ViewModel
{
    public class AddMenuDetailsModel
    {
        
            public int Id { get; set; }
            public int MenuId { get; set; }
            public int CategoryId { get; set; }

            public string ItemId { get; set; }

            public bool IsActive { get; set; }
        
    }
}
