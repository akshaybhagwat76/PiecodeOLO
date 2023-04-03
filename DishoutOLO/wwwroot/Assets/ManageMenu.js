var retvalDetails = true;
var MenuAvailabilities = [];

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
                MenuName: $("#MenuName").val(),
                CategoryId: $("#CategoryId").val(),
                MenuPrice: $("#MenuPrice").val(),
                ProgramId: $("#ProgramId").select2('data').map(x => x.id).toString(),
                Description: $("#Description").val(),
                IsActive: $("#IsActive").val() == "True" ? true : false,
                ListAvaliblities: MenuAvailabilities
            }

            $.ajax({
                url: "/Menu/AddOrUpdateMenu",
                data: data,
                type: 'POST', // For jQuery < 1.9
                success: function (data) {
                    if (!data.isSuccess) {
                        // $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();
                        $("#lblError").addClass("error").text(data.message.toString()).show();


                    }
                    else {
                        window.location.href = '/Menu/Index'
                    }
                }
            });
        }
    })
});
$('#deletebtn').click(function () { $('.table tbody').empty(); $('.table thead').hide(); })

$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');
    $('#ProgramId').select2();
}); $('#delete-btn').click(function () {
    var id = $('#deleteModal').data('id');
    $.ajax({

        type: "GET",
        url: "/Menu/DeleteMenuAvailabilities",
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
            }
            else {
                $('#deleteModal').modal('hide');
                loadAllMenu();
            }
        },
        error: function (error) {
        }
    });
});


$(document).ready(function () {

    var id = $("#Id").val();
    if (id != null && id.length > 0 && parseInt(id) > 0) {
        $('#ProgramId').select2().val($("#programIds").val().split(',').map(Number)).trigger("change")
    }
})
$('#btn-check').click(function () {
    if ($('.chooseplus').is(':hidden')) {
        $('.chooseplus').show();
    } else {
        $('.chooseplus ').hide();
    }
});


$('#dataupload').on('click', function () {

    $("thead").show();
    var week = $('#week').val();
    var fromtime = $('#fromtime').val();
    var endtime = $('#endtime').val();

    var obj = {
        "week": week,
        "fromtime": fromtime,
        "endtime": endtime,
    }
    if (retvalDetails) {
        debugger
        var alreadyExist = false;
        if (MenuAvailabilities != null && MenuAvailabilities.length > 0) {

            var alreadyExist = MenuAvailabilities.some(x => parseInt(x.fromtime) <= parseInt(obj.fromtime) && parseInt(x.endtime) >= parseInt(obj.endtime) && obj.week == x.week);
            if (alreadyExist) {

                alert("Please choose different time");
            }

        }
        if (!alreadyExist) {

            MenuAvailabilities.push(obj);
            $("#trpolicy tbody tr").remove();

            if (week != '---SelectName---' && fromtime != '' && endtime != '') {
                $('#deletebtn').show();

                var data = '<tr class="trpolicy" data-id=' + MenuAvailabilities.length + '><td>' + week + '</td> <td>' + fromtime + '</td> <td> ' + endtime + '</td><td><a class="deletepolicy"> <i class="fa fa-times" aria-hidden="true"></i> </a></td></tr>';
                $('tbody').append(data);
                $('#week').val('');
                $('#fromtime').val('');
                $("#endtime").val('');
            }
        }

    }
    var htmlString = $(form).html();

});

let menuAvailId = 0;
function deletemenuAvaliblities() {
    $('#delete-btn').on('click', function () {
        debugger
        var rowIndex = $(this).find("tr.trpolicy").data("id");
         menuAvailId = $(this).parent().parent().data("id");
        if (menuAvailId.length > 0) {
            menuAvailId = parseInt(menuAvailId);
        }
        console.log($(this).parent().parent().remove())
        delete MenuAvailabilities[parseInt($(this).closest('tr').attr('data-id'))];
        

    })

   
}

$("#weektbl").on("click", "a.deletepolicy", function () {
    $('#deleteModal').data('id', menuAvailId).modal('show');
    $('#deleteModal').modal('show');
});







