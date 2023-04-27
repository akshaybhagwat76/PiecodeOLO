
$(".checkit").on("click", function () {
    // var id = $(this).data('id');

    if ($(this).is(':checked') == true) {

        Swal.fire({
            title: 'Are You Sure You Want active!',
            //text: "Are You Sure You Want active!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                //id = id

                toastr.success('Status Has Been Changed.')

            }
        })

    } else {
        Swal.fire({
            title: 'Are You Sure You Want deactive',
            //text: "Are You Sure You Want deactive",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                //id = id

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
 
$(".draggable").draggable({
    revert: true,
    revertDuration: 0
});

$(".droppable").droppable({
   
    activeClass: "active",
    hoverClass: "hover",
   
    accept: function (draggable) {
        var droppable = $(this);

        var draggablesDropable = draggable.parent();
         
    },

    drop: function (event, ui) {
        debugger
        var droppable = $(this);
        var draggable = ui.draggable;
        var draggablesDropable = draggable.parent();
        if (droppable.is(draggablesDropable)) {
            return;
        }
        else if (!droppable.find(".draggable").size()) {
            droppable.append(draggable);
        }
        else if (droppable.parent().is(draggablesDropable.parent())) {
            if (droppable.parent().find(".droppable").index(draggablesDropable) > droppable.parent().find(".droppable").index(droppable)) {
                draggablesDropable.insertBefore(droppable);
            }

            else {
                draggablesDropable.insertAfter(droppable);
            }
        }
        else if (droppable.parent().find(".draggable").size() < droppable.parent().find(".droppable").size()) {
           
            var emptyDroppable = $($.grep(droppable.parent().find(".droppable"), function (item) {
               
                return !$(item).find(".draggable").size();
            })).first();

            var draggablesDropableClone = draggablesDropable.clone().insertBefore(draggablesDropable);

            if (droppable.parent().find(".droppable").index(emptyDroppable) > droppable.parent().find(".droppable").index(droppable)) {
                draggablesDropable.insertBefore(droppable);
            }

            else {
                draggablesDropable.insertAfter(droppable);
            }

            draggable.css({ "top": 0, "left": 0 });

            draggablesDropableClone.before(emptyDroppable).remove();
        }
    }
});
debugger
$('#activeclass .Selectitemlist').click(function () {
    $(this).addClass('active').siblings().removeClass('active');
});