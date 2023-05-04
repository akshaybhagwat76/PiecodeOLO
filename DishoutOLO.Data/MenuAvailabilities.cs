
namespace DishoutOLO.Data
{
    public class MenuAvailabilities:BaseEntity
    {
        public string endtime { get; set; }

        public string fromtime { get; set; }

        public int MenuId { get; set; }
        public string week { get; set; }

    }
}
