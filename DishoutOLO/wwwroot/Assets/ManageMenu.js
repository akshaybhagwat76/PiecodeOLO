$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');

    $('#ProgramId').select2();   


            
});
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

    if (retval) {
        var data = {
            id: $("#Id").val(),
            MenuName: $("#MenuName").val(),
            CategoryId: $("#CategoryId").val(),
            MenuPrice: $("#MenuPrice").val(),
            ProgramId: $("#ProgramId").select2('data').map(x => x.id).toString(),
            Description: $("#Description").val(),
            IsActive: $("#IsActive").val() == "True" ? true : false,

        }
 
        $.ajax({
            url: "/Menu/AddOrUpdateMenu",
            data: data,
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
})


$(document).ready(function () {
    $('#btn-admin').click(function () {
        if ($('.sel-wek').is(':hidden')) {
            $('.sel-wek').show();
        } else {
            $('.sel-wek ').hide();
        }
    });
    var id = $("#Id").val();
    if (id != null && id.length > 0 && parseInt(id) > 0) {
        $('#ProgramId').select2().val($("#programIds").val().split(',').map(Number)).trigger("change")
    }
});
