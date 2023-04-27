var alreadyExist = false;

$(".checkit").on("click", function () {
    if ($(this).is(':checked') == true) {

        Swal.fire({
            title: 'Are You Sure You Want active!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {

                toastr.success('Status Has Been Changed.')

            }
        })

    } else {
        Swal.fire({
            title: 'Are You Sure You Want deactive',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {

                toastr.success('Status Has Been Changed.')

            }
        })
    }
})  
 
$(document).ready(function () {

    $("#selUser").select2();

    var username = $('#selUser option:selected').text();
    var userid = $('#selUser').val();

    $('#result').html("id : " + userid + ", name : " + username);
     
});
 


$(function () {
    $('.droptrue').on('click', 'li', function () {
        $(this).toggleClass('selected');
    });

    $("ul.droptrue").sortable({
       
        connectWith: 'ul.droptrue',
        opacity: 0.6,
        revert: true,
        helper: function (e, item) {
            console.log('parent-helper');
            console.log(item);
            if (!item.hasClass('selected'))
                item.addClass('selected');
            var elements = $('.selected').not('.ui-sortable-placeholder').clone();
            var helper = $('<ul/>');
            item.siblings('.selected').addClass('hidden');
            return helper.append(elements);
        },
        start: function (e, ui) {
            var elements = ui.item.siblings('.selected.hidden').not('.ui-sortable-placeholder');
            ui.item.data('items', elements);
        },
        receive: function (e, ui) {
            ui.item.before(ui.item.data('items'));
        },
        stop: function (e, ui) {
            ui.item.siblings('.selected').removeClass('hidden');
            $('.selected').removeClass('selected');
        },
        update: function () {
            updatePostOrder();
        }
    });


    $("#sortable1, #sortable2 ").disableSelection();
    $("#sortable1, #sortable2").css('minHeight', $("#sortable1, #sortable2").height() + "px");
});
 
function updatePostOrder() {
    var arr = [];
    $("#sortable2 li").each(function () {
        arr.push($(this).attr('id'));
    });
    $('#postOrder').val(arr.join(','));
}

 
$('#activeclass').click(function () {
    debugger
    var categoryId = $("#activeclass").val();
    
    if (categoryId != null && categoryId.length > 0 && categoryId++)
        $.ajax({
            url: '/MenuBuilder/GetAllMenuBuilder',
            type: 'Get',
            dataType: 'Json',
            data: { categoryId: parseInt(categoryId) },
            success: function (res) {
                $("#sortable2").empty();
                $.each(res, function (i, row) {
                    $("#sortable2").append("<ul value='" + row.categoryId + "'>" + row.categoryName + "</ul>")
                });
                $("#sortable2").trigger("change");
            }
        })
});



$(document).ready(function () {
    $('#activeclass .Selectitemlist').click(function () {
        $('#activeclass .Selectitemlist').removeClass("active");
        $(this).addClass("active");
    });
});