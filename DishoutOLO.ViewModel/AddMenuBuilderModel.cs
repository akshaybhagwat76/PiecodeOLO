
namespace DishoutOLO.ViewModel
{
    public class AddMenuBuilderModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int CategoryId { get; set; }
        public int MenuId { get; set; }
        public string ItemId { get; set; }
        public string CategoryName { get; set; }
        public string Descrition { get; set; }
        public string Week { get; set; }
        public List<AddMenuAvaliblities> ListAvaliblities { get; set; }
        public List<AddItemModel> ItemModels { get; set; }
        public int MenuDetailId { get; set; }
      
    }

    public class ListMenuBuilderModel
    {

        public int Id { get; set; }
        public string MenuName { get; set; }
        public int CategoryId { get; set; }
        public string ItemId { get; set; }
        public int MenuId { get; set; }
        public string CategoryName { get; set; }
        public string Descrition { get; set; }
        public string Week { get; set; }
        public List<AddMenuAvaliblities> ListAvaliblities { get; set; }
        public List<AddItemModel> ItemModels { get; set; }
        public int MenuDetailId { get; set; }

        
        

    }



}
