$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
  
    var id = $("#Id").val();
    if (id == 0) {
        $("#StartDate").val("");
        $("#EndDate").val("");
    }
    $("#btn-Add").on("click", function () {
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

                       $("#lblError").addClass("error").text(data.message.toString()).show();

                    }
                    else {
                        window.location.href = '/Coupen/Index'
                    }
                }
            })
        }
        
    });
   
    $(".dtpicker").datepicker({
        format: 'DD-MM-YYYY'
    });
     

   
})