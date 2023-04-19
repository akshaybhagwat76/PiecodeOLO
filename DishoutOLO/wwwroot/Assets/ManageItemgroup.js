$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    $('.DefaultSuccess').click(function () {
        toastr.success('Item Added Successfully.')
    });
   

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
                ItemGroup: $("#ItemGroup").val(),
                DisplayOrder: $("#DisplayOrder").val(),
                ItemId: $("#ItemId").val(),
                IsActive: $("#IsActive").val() == "True" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/ItemGroup/AddOrUpdateItemGroup",
                data: { itemgroupVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();

                    }
                    else {
                        window.location.href = '/ItemGroup/Index'
                    }
                }
            });
        }
    });
    //$("#dataupload").click(function () {

    //});
});