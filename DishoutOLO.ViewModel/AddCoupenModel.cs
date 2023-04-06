

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DishoutOLO.ViewModel
{
    public class AddCoupenModel
    {
        public int Id { get; set; }

        [DisplayName("Coupon Name")]
        public string CouponName { get; set; }


        [DisplayName("Coupon Code")]
        public string? CouponCode { get; set; }

        [DisplayName("MinOrder Amount")]
        public decimal MinOrderAmount { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public decimal Discount { get; set; }

        [DisplayName("Redemption Type")]
        public string? RedemptionType { get; set; }

        public string? Description { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Discount Type Percentageval")]
       public decimal DiscountTypePercentageval { get; set; }
    }

    public class UpdateCoupenModel
    {
        public int Id { get; set; }

        public string CouponName { get; set; }

        public string CouponCode { get; set; }

        public decimal MinOrderAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Discount { get; set; }

        public string? RedemptionType { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
        public decimal DiscountTypePercentageval { get; set; }
    }

    public class ListCoupenModel
    {
        public int Id { get; set; }

        public string CouponName { get; set; }

        public string CouponCode { get; set; }

        public decimal MinOrderAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Discount { get; set; }

        public string RedemptionType { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }

        public decimal DiscountTypePercentageval { get; set; }
    }

    public class DeleteCoupenModel
    {
        public int Id { get; set; }

       
    }
}
