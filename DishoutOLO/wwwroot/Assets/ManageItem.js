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

        if ($('#itemId').val().length > 0) {
            Ajaxform(retval)
        } else {
            Ajaxwithform(retval)
        }
            


    })
});

$(document).ready(function () {

    $(".Taxmenu").hide();
    $("#TaxYes").click(function () {
        $(".Taxmenu").show();
    });
    $("#TaxNo").click(function () {
        $(".Taxmenu").hide();
    });
});

$(document).ready(function () {

    $(".txtchoice").hide();
    $("#rdYesType").click(function () {
        $(".txtchoice").show();
    });
    $("#rdNoType").click(function () {
        $(".txtchoice").hide();
    });
});

function Ajaxform(retval) {
    if (retval) {
        var data = {
            id: $("#Id").val(),
            CategoryId: $("#CategoryId").val(),
            ItemName: $("#ItemName").val(),
            ItemImage: $("#ItemImage").val(),
            IsCombo: $("#IsCombo").is(':checked') ? true : false,
            IsVeg: $("#Veg").val() == 'Veg' ? true : false,
            IsTax: $("#t1").val() == 'Yes' ? true : false,
            ItemDescription: $("#ItemDescription").val(),
            IsVeg: $("#Choices").val() == 'Veg' ? true : false,
            IsChooseChoice: $(".ChoiceType1").val() == 'rdYesType' ? true : false

    }
    }
        var formData = new FormData();
        formData.append("Id", data.id);
        formData.append("CategoryId", data.CategoryId);
        formData.append("ItemName", data.ItemName);
        formData.append("File", $("#itemId")[0].files[0]);
        formData.append("IsVeg", data.IsVeg);
        formData.append("IsCombo", data.IsCombo);
        formData.append("IsTax", data.IsTax);
    formData.append("ItemDescription", data.ItemDescription);
    formData.append("IsChooseChoice", data.IsChooseChoice)
        $.ajax({
            type: "POST",
            url: "/Item/AddOrUpdateItem",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                if (!data.isSuccess) {
                    $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();

                }
                else {
                    window.location.href = '/Item/Index'

                }
            }
        });
    }


function Ajaxwithform(retval) {
    if (retval) {
        
        var data = {
            id: $("#Id").val(),
            CategoryId: $("#CategoryId").val(),
            ItemName: $("#ItemName").val(),
            ItemImage: $("#ItemImage").val(),
            IsCombo: $("#IsCombo").is(':checked') ? true : false,
            IsVeg: $("#Veg").val() == 'Veg' ? true : false,
            IsTax: $("#t1").val() == 'Yes' ? true : false,
            ItemDescription: $("#ItemDescription").val(),
            IsChooseChoice: $(".ChoiceType1").val() == 'rdYesType' ? true : false,
            MayonnaiseOption: $('#MayonnaiseOption').val(),
            extraChickenOption: $('#extraChickenOption').val(),
            extraCheeseOption: $('#extraCheeseOption').val()
    }

        }

        console.log(data);  
                $.ajax({
                    type: "POST",
                url: "/Item/AddOrUpdateItemSimple",
                data: data,
                cache: false,
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();

                    }
                    else {
                        window.location.href = '/Item/Index'

                    }
                }
            });
    }




 

