var retvalDetails = true;
var MenuAvailabilities = [];

$('#deletebtn').click(function () { $('.table tbody').empty(); $('.table thead').hide(); })



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
            lstAval: MenuAvailabilities
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
    debugger
    $("thead").show();

    $("#lblError").removeClass("success").removeClass("error").text('');

    var week = $('#week').val();
    var fromtime = $('#fromtime').val();
    var endtime = $('#endtime').val();

    var obj = {
        "week": week,
        "fromtime": fromtime,
        "endtime": endtime,
    }
    if (retvalDetails) {
        MenuAvailabilities.push(obj);

        $('#week').val('');
        $('#fromtime').val('');
        $("#endtime").val('');

    
            if (week != '---SelectName---' && fromtime != '' && endtime != '') {
                $('#deletebtn').show();
               // var data = '<tr class="trpolicy" data-id=' + MenuAvailabilities.length + '><td>' + week + '</td> <td>' + fromtime + '</td> <td> ' + endtime + '</td><td><a class="deletepolicy" href="#"> <i class="fa fa-times" aria-hidden="true"></i> </a></td></tr>';
               //var  t = $('#weektbl').DataTable();

                var data= '<tr class="trpolicy" data-id=' + MenuAvailabilities.length + '><td>' +
                    week + '</td> <td>' + fromtime + '</td> <td> ' +endtime
                     + '</td><td><a class="deletepolicy" href="#"> <i class="fa fa-times" aria-hidden="true"></i> </a></td></tr>';

                $('tbody').append(data);
                
            }
           
        
        $('.deletepolicy').on('click', function () {
            var rowIndex = $(this).find("tr.trpolicy").data("id");
            debugger
            console.log($(this).parent().parent().remove())
            delete MenuAvailabilities[parseInt($(this).closest('tr').attr('data-id'))];
        })
                  

    }
});


    