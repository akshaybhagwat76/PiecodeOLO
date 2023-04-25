
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




//$(function () {
//    $("#userFacets,#allFacets").sortable({
//        connectWith: "ul",
//        placeholder: "placeholder",
//        delay: 150
//    })
//        .disableSelection()
//        .dblclick(function (e) {
//            var item = e.target;
//            if (e.currentTarget.id === 'userFacets') {
//                $(item).fadeIn('fast', function () {
//                    $(item).appendTo($('#allFacets')).fadeIn('slow');
//                });
//            } else {
//                $(item).fadeOut('fast', function () {
//                    $(item).appendTo($('#userFacets')).fadeIn('slow');
//                });
//            }
//        });
//});


$(init);
function init() {
    $("#userFacets, #allFacets").sortable({
        connectWith: ".connected-sortable",
        stack: '.connected-sortable'
    }).disableSelection();
}    

$(".Selectitemlist").on('click', function () {
    debugger
    var getValue = $(this).val('id');
    
    alert(getValue);
});

