$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    if ($("#hdnStatus").val() == 'true') {
        $("#Status").attr('checked', true);
    }
    $(".lblStatusTxt").text($("#Status").is(':checked') ? "Active" : "Deactive");



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
        if (retval) {
            var data = {
                id: $("#Id").val(),
                CategoryName: $("#CategoryName").val(),
                Status: $("#Status").is(':checked'),
                IsActive: $("#IsActive").val() == "true" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/Category/AddOrUpdateCategory",
                data: { categoryVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.message.toString()).show();
                    }
                    else {
                        window.location.href = '/Category/Index'
                    }
                }
            });
        }
       
    })
    $("#Status").change(function (e) {
        $(".lblStatusTxt").text($("#Status").is(':checked') ? "Active" : "Deactive")
    })

});