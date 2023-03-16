$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    $("#btn-submit").on("click", function () {
     
        $("#lblError").removeClass("success").removeClass("error").text('');
        var retval = true;
        $("#myForm .required").each(function () {
            if (!$(this).val()) {
            retval = false;
            }
            else {
            $(this).removeClass("error");
            }
        });

        if ($('#menuId').val().length > 0) {
            
            Ajaxform(retval)
         al
        } else {
            Ajaxwithform(retval)
        }
            
        
    })
});

function Ajaxform(retval) {
    if (retval) {
        var data = {
            id: $("#Id").val(),
            MenuName: $("#MenuName").val(),
            CategoryId: $("#CategoryId").val(),
            MenuPrice: $("#MenuPrice").val(),
            Image: $("#Image").val(),
            IsActive: $("#IsActive").val() == "True" ? true : false,

        }
        var formData = new FormData();
        formData.append("Id", data.id);
        formData.append("MenuName", data.MenuName);
        formData.append("CategoryId", data.CategoryId);
        formData.append("MenuPrice", data.MenuPrice);
        formData.append("File", $("#menuId")[0].files[0]);
        formData.append("IsActive", data.IsActive);
             
        $.ajax({
            url: "/Menu/AddOrUpdateMenu",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST', // For jQuery < 1.9
            success: function (data) {
                if (!data.isSuccess) {
                    $("#lblError").addClass("error").text(data.message.toString()).show();
                }
                else {
                    window.location.href = '/Menu/Index'
                }
            }
        });
    }
}

function Ajaxwithform(retval) {
    if (retval) {
        var data = {
            id: $("#Id").val(),
            MenuName: $("#MenuName").val(),
            CategoryId: $("#CategoryId").val(),
            MenuPrice: $("#MenuPrice").val(),
            Image: $("#Image").val(),
            IsActive: $("#IsActive").val() == "True" ? true : false,

        }
        $.ajax({
            url: "/Menu/AddOrUpdateMenuSimple",
            data: data,
            cache: false,
            
            type: 'POST', // For jQuery < 1.9
            success: function (data) {
                if (!data.isSuccess) {
                    $("#lblError").addClass("error").text(data.message.toString()).show();
                }
                else {
                    window.location.href = '/Menu/Index'
                }
            }
        });

    }
}
