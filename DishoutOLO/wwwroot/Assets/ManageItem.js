$(document).ready(function () {
   
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

        var data = {
            Id: $("#Id").val(),
            ItemName: $("#ItemName").val(),
            CategoryId: $("#CategoryId").select2('data').map(x => x.id).toString(),
            ItemImage: $("#ItemImage").val(),
            ItemDescription: $("#ItemDescription").val(),
            UnitCost: $("#UnitCost").val(),
            MSRP: $("#MSRP").val(),
            TaxRate1: $("#TaxRate1").val(),
            TaxRate2: $("#TaxRate2").val(),
            TaxRate3: $("#TaxRate3").val(),
            TaxRate4: $("#TaxRate4").val()

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

        if (retval) {
            
            $.ajax({
                type: "POST",
                url: "/Item/AddOrUpdateItem",
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (!data.isSuccess) {
                        //$("#lblError").addClass("error").text(data.errors[0].errorDescription).show();
                        $("#lblError").addClass("error").text(data.message.toString()).show();

                    }
                    else {
                        window.location.href = '/Item/Index'

                    }
                }
            });

        }
    })
});
$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    $('#CategoryId').select2();

    var id = $("#Id").val();
    if (id != null && id.length > 0 && parseInt(id) > 0) {
        $('#CategoryId').select2().val($("#categoryIds").val().split(',').map(Number)).trigger("change")
    }
})

