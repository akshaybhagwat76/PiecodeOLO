$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
        


    var id = $("#Id").val();
    if (id == 0) {
        $("#Startdate").val("");
        $("#Enddate").val("");
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
        Startdate: $("#Startdate").val(),
        Enddate: $("#Enddate").val(),
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
})
$(document).ready(function () {

    $(function () {
        $("#Startdate").datepicker({
            minDate: 0
            
        });
    });

    $(function () {
        $("#Enddate").datepicker({
            minDate: 0,
        });
      
    });

   
})