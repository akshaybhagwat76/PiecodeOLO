$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');

    debugger

    $("#btn-Add ").on("click", function () {
        $("#lblError").removeClass("success").removeClass("error").text('');
        var retval = true;
        $("#myForm .required").each(function () {
            if (!$(this).val()) {
                $(this).addClass("error");
                retval = false;
            }
            else {
                $(this).removeClass("error");
            }
           
        });

        debugger
    var data = {
        id: $("#Id").val(),
        CouponName: $("#CouponName").val(),
        CouponCode: $("#CouponCode").val(),
        MinOrderAmount: $("#MinOrderAmount").val(),
        StartDate: $("#StartDate").val(),
        EndDate: $("#EndDate").val(),
        Discount: $("#Discount").val(),
        RedemptionType: $("#RedemptionType").val(),
        Description: $("#Description").val(),
        DiscountTypePercentageval: $("#DiscountTypePercentageval").val(),
        IsActive: $("#IsActive").val() == "true" ? true : false
        }
        if (retval) {
            $.ajax({
                type: "POST",
                url: "/Coupen/AddOrUpdateCoupen",
                data: { coupenVM: data },

                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();

                    }
                    else {
                        window.location.href = '/Coupen/Index'
                    }
                }
            })
        }
        
    });
})
$(function () {
    debugger
    $("#datepicker").datepicker({
        minDate: new Date(2021, 0, 1), // January 1, 2021
        maxDate: new Date(2023, 03, 04), // December 31, 2023
    });
});