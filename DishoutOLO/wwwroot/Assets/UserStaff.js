var table;
$("document").ready(function () {
    loadAllUserStaff();
})
$("#userStaffTbl").on("click", "a#btn-delete", function () {
    var uid = $(this).data('id');
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
            id = uid
            deleteUserStaff();
            toastr.success('Record Deleted Successfully.')


        }
    })
});

function deleteUserStaff() {
    var id = $('#deleteModal').data('id');
    $.ajax({
        type: "GET",
        url: "/UserStaff/DeleteUserStaff",
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


function loadAllUserStaff() {
    var url = "/UserStaff/GetAllUserStaff"
    
    table = $("#userStaffTbl").DataTable({

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
                "data": "userName"
            },
            {
                "data": "joiningDate",
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();

                }
            },
            {
                "data": "email"
            },
                {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/UserStaff/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
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

