

namespace DishoutOLO.Data
{
    public class Coupen:BaseEntity
    {

        public string CouponName {  get; set; }

        public string CouponCode { get; set; }  

        public decimal MinOrderAmount { get; set; }

        public DateTime StartDate { get; set;}

        public DateTime EndDate { get; set;}

        public decimal Discount { get; set; }        

        public  string  RedemptionType { get; set; }    

        public string Description { get; set; }

        public decimal DiscountTypePercentageval { get; set; } 
    }
}
