var table,id=0;
$("document").ready(function () {
    loadAllItemgroup();
    


})
$("#itemgroupTbl").on("click", "a#btn-delete", function () {
    var gid = $(this).data('id');
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
            id = gid
            deleteItemgroup();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteItemgroup() {
    $.ajax({
        type: "GET",
        url: "/Itemgroup/DeleteItemGroup",
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


function loadAllItemgroup() {
    var url = "/Itemgroup/GetAllItemGroup"

    table = $("#itemgroupTbl").DataTable({

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
                "data": "itemGroup"
            },
            {
                "data": "itemName"
            },
            {
                "data": "displayOrder"
            },

            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Itemgroup/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
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

