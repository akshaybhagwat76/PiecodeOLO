//const { data } = require("jquery");

var table,id=0;
$("document").ready(function () {
    loadAllCoupens();

})
$("#coupenTbl").on("click", "a#btn-delete", function () {
    var cid = $(this).data('id');
    Swal.fire({
        title: 'Are you sure?',
        text: "You will not be able to recover this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            id = cid
            deletCoupen();
            toastr.success('Record Deleted Successfully.')

        }
    })
});
function  deletCoupen() {
    $.ajax({
        type: "GET",
        url: "/Coupen/DeleteCoupen",
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
            }
            else {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
            }
        },
        error: function (error) {
        }
    });
}




function loadAllCoupens() {

    var url = "/Coupen/GetAllCoupen"
    table = $("#coupenTbl").DataTable({

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
                "data": "couponName"
            },
            {
                "data": "couponCode"
            },
            
            {
                "data": "startDate",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();

                }
            
                
            },
                       
            {
                "data": "endDate",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
s                   }
            },
            {
                "data": "discount"
            },
           

            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Coupen/Edit/` + full.id + `" data-id="` + full.id + `" onclick="show()" class="btn btn-success btn-sm" title="Edit">
                                    <i class="fa fa-edit"></i>
                             </a>
                             <a href="javascript:void(0)" id="btn-delete" data-id="`+ full.id + `" class="btn btn-danger btn-sm" title="Delete">
                                    <i class="fa fa-trash"></i>
                             </a>`;
                }
            }

        ],

    });

}

