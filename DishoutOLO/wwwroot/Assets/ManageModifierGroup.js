$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');

    $("#btn-submit").on("click", function () {
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
                ModifierGroupName: $("#ModifierGroupName").val(),
                price: $("#price").val(),
                ModifierId: $("#ModifierId").val(),
                IsActive: $("#IsActive").val() == "true" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/ModifierGroup/AddOrUpdateModifierGroup",
                data: { modifiergroupVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();
                    }
                    else {
                        window.location.href = '/ModifierGroup/Index'
                    }
                }
            });
        }
    })
});