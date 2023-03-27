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
            Ajaxwithform(retval);
        }



    })
});



function Ajaxform(retval) {
    if (retval) {
        var data = {
            Id: $("#Id").val(),
            CategoryId: $("#CategoryId").val(),
            ItemName: $("#ItemName").val(),
            ItemImage: $("#ItemImage").val(),
            ItemDescription: $("#ItemDescription").val(),
            UnitCost: $("#UnitCost").val(),
            MSRP: $("#MSRP").val(),
            TaxRate1:$("#TaxRate1").val(),
            TaxRate2:$("#TaxRate2").val(),
            TaxRate3:$("#TaxRate3").val(),
            TaxRate4: $("#TaxRate4").val(),
           
        }
    }
    
    var formData = new FormData();
    formData.append("Id", data.Id);
    formData.append("CategoryId", data.CategoryId);
    formData.append("ItemName", data.ItemName);
    formData.append("File", $("#itemId")[0].files[0]);
    formData.append("ItemDescription", data.ItemDescription);
    formData.append("UnitCost", data.UnitCost);
    formData.append("MSRP", data.MSRP);
    formData.append("TaxRate1", data.TaxRate1);
    formData.append("TaxRate2", data.TaxRate2);
    formData.append("TaxRate3", data.TaxRate3);
    formData.append("TaxRate4", data.TaxRate4);


    $.ajax({
        type: "POST",
        url: "/Item/AddOrUpdateItem",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            if (!data.isSuccess) {
                $("#lblError").addClass("error").text(data.message.toString()).show();

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
            ItemDescription: $("#ItemDescription").val(),
            UnitCost: $("#UnitCost").val(),
            MSRP: $("#MSRP").val(),
            TaxRate1: $("#TaxRate1").val(),
            TaxRate2: $("#TaxRate2").val(),
            TaxRate3: $("#TaxRate3").val(),
            TaxRate4: $("#TaxRate4").val(),
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
                $("#lblError").addClass("error").text(data.message.toString()).show();

            }
            else {
                window.location.href = '/Item/Index'

            }
        }
    });
}

    

//$(document).ready(function () {
//    $('.btn-sm').on("click", function (e) {
//        $('#imageurl').toggle('show');
//    });
//});

$(document).ready(function () {
    $("#imageurl").hide();
    $("#btn-img").click(function () {
        $("#imageurl").show();
    });
   
});