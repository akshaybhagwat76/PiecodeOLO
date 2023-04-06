

var table;
$("document").ready(function () {
    loadAllCustomer();

    $('#btn-deactive').on('click', function () {
        $('#deactivemodel').modal('toggle');
        toastr.success('Status Has Been Changed!')
    })
    $('#btn-active').on('click', function () {
        $('#activemodel').modal('toggle');
        toastr.success('Status Has Been Changed!')
    })
});
$("#customerTbl").on("change", "#checkit", function () {
    var id = $(this).data('id');
    if ($(this).is(':checked') == true) {

        $('#deactivemodel').data('id', id).modal('show');
        $('#deactivemodel').modal('show');

    }
    else {
        $('#activemodel').data('id', id).modal('show');
        $('#activemodel').modal('show');

    }


});
function loadAllCustomer() {

    var url = "/Customer/GetAllCustomer"
    table = $("#customerTbl").DataTable({

        "searching": true,
        "serverSide": true,
        "bFilter": true,
        "orderMulti": false,
        "ajax": {
            url: url,
            type: "POST",
            datatype: "json"
        },

        "columns": [
            {
                "data": "firstName"
            },
            {
                "data": "lastName"
            },
            {
                "data": "email"
            },
            {
                "data": "address1"
            },
            {
                "data": "address2"
            },
            {
                "data": "phone"
            },
            {
                orderable: false,
                "render": function (data, type, row, meta) {

                    return `<label class="switch">
                            <input type="checkbox" id="checkit">
                             <span class="slider round"></span>
                              </label>`



                }
            },

        ],

    });



}







