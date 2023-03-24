

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
$("#customerTbl").on("change", "#back", function () {
    var id = $(this).data('id');
    //var checked = $(this).is(':checked') == true;
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
                "render": function () {

                    return ` <input type="checkbox" name="option" id="back">`
                                                               

                }
            },

        ],
       
    }); 
         
    

}


$('#back').change(function () {
    if ($('#back').is(':checked') == true) {
        $('#customerTbl').prop('disabled', true);

    } else {
        $('#customerTbl').val('').prop('disabled', false);

    }

});
