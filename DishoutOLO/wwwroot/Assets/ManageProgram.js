$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
   
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
                ProgramName: $("#ProgramName").val(),
                IsActive: $("#IsActive").val() == "true" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/Program/AddOrUpdateProgram",
                data: { programVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.message.toString()).show();
                    }
                    else {
                        window.location.href = '/Program/Index'
                    }
                }
            });
        }

    })
        

});