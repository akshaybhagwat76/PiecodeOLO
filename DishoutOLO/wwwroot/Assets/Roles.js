var table;
$("document").ready(function () {
    loadAllRoles();
})
$("#rolesTbl").on("click", "a#btn-delete", function () {
    var rid = $(this).data('id');
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
            id = rid
            deleteRoles();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteRoles() {
    var id = $('#deleteModal').data('id');
    $.ajax({
        type: "GET",
        url: "/Roles/DeleteRoles",
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


function loadAllRoles() {
    var url = "/Roles/GetAllRoles"

    table = $("#rolesTbl").DataTable({

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
                "data": "rolesName"
            },
           
            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Roles/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
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

