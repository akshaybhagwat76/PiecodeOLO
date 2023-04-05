

using System.ComponentModel.DataAnnotations;

namespace DishoutOLO.ViewModel
{
    public class AddCoupenModel
    {
        public int Id { get; set; }

        public string? CouponName { get; set; }

        public string? CouponCode { get; set; }

        public decimal MinOrderAmount { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public decimal Discount { get; set; }

        public string? RedemptionType { get; set; }

        public string? Description { get; set; }
        public bool IsActive { get; set; }

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
