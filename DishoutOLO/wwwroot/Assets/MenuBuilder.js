
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
    $('[data-toggle="tooltip"]').tooltip();
});





$(document).ready(function () {
     
      $("#selUser").select2();
     
        var username = $('#selUser option:selected').text();
        var userid = $('#selUser').val();

    $('#result').html("id : " + userid + ", name : " + username);
     
});

