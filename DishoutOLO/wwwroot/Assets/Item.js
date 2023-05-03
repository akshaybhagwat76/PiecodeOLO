
var table,id=0;
$("document").ready(function () {
    loadAllItem();
 })
$("#itemTbl").on("click", "a#btn-delete", function () {
    var tid = $(this).data('id');
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
            id = tid
            deleteItem();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteItem() {
    $.ajax({
        type: "GET",
        url: "/Item/DeleteItem",
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
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

var index = 0;
function loadAllItem() {
    var url = "/Item/GetAllItem"

    table = $("#itemTbl").DataTable({
        "orderCellsTop": true,
        "fixedHeader": true,
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
                "data": "itemName"
            },
                
            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Item/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
                 <i class="fa fa-edit"></i>
                 </a>

                 <a href="javascript:void(0)" id="btn-delete" data-id="`+ full.id + `" class="btn btn-danger btn-sm" title="Delete">
                                    <i class="fa fa-trash"></i>
                             </a>`;

                }
            }
        ]
    })
}   




