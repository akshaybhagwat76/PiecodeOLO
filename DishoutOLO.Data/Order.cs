namespace DishoutOLO.Data
{
    public class Order:BaseEntity
    {
        public int MenuId { get; set; } 
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public DateTime Orderdate { get; set; }
    }
}
