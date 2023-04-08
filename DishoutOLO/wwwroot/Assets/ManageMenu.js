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

$("#weektbl").on("click", "a.deletepolicy", function () {
    var id = $(this).data('id');
    $('#deleteModal').data('id', id).modal('show');
    $('#deleteModal').modal('show');
});
let menuavailid = 0;
function deletemenuAvaliblities(id) {
    
    $.ajax({

        type: "GET",
        url: "/Menu/DeleteMenuAvailabilities?id=" + id,
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
                table.ajax.reload();
            }
            else {
                $('#deleteModal').modal('hide');

            }
        },
        error: function (error) {
        }
    });
    console.log($(this).parent().parent().remove())
}









