var alreadyExist = false;
var categoryId = 0;
var menuId = 0;
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
 


function goodbye(e) {
    debugger
    var itemsIds = [];

    $('#sortable2 li').map(function () {
        itemsIds.push($(this)[0].id)
    });
    
}
window.onbeforeunload = goodbye;


$(function () { 
    $('.droptrue').on('click', 'li', function () {
        $(this).toggleClass('selected');
    });

    $("ul.droptrue").sortable({
       
        connectWith: 'ul.droptrue',
        opacity: 0.6,
        revert: true,
        helper: function (e, item) {
            debugger
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
            debugger
            console.log('parent-start');
            console.log(ui);
            var elements = ui.item.siblings('.selected.hidden').not('.ui-sortable-placeholder');
            ui.item.data('items', elements);
        },
        receive: function (e, ui) {
            debugger
            console.log('parent-receive');
            console.log(ui);
            ui.item.before(ui.item.data('items'));
        },
        stop: function (e, ui) {
            debugger
            console.log('parent-stop');
            console.log(ui);
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



 

$('#activeclass .Selectitemlist').click(function () {
    $('#activeclass .Selectitemlist').removeClass("active");
    $(this).addClass("active");
});



$('.Selectitemlist').click(function () {
    var categoryName = $(this).find("div.catDiv")[0].id;
    debugger
    var menuId = $(this)[0].id;
    menuId = parseInt(menuId);

    var catId = $(this).find("div.catDiv")[0].attributes["data-catid"].value;
    categoryId = parseInt(catId);
    $("#categoryContainer").find("h2").text("Category : " +categoryName);
});
