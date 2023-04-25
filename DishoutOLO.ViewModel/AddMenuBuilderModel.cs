
namespace DishoutOLO.ViewModel
{
    public class AddMenuBuilderModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Descrition { get; set; }
        public string Week { get; set; }
        //public string FullTime { get; set; }
        public List<AddMenuAvaliblities> ListAvaliblities { get; set; }
        public List<AddItemModel> ItemModels { get; set; }


    }


}
