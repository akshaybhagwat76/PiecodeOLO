var table;
$("document").ready(function () {
    loadAllModifier();
})
$("#ModifierTbl").on("click", "a#btn-delete", function () {
    var mid = $(this).data('id');
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
            id = mid
            deleteModifier();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteModifier() {
    var id = $('#deleteModal').data('id');
    $.ajax({
        type: "GET",
        url: "/Modifier/DeleteModifier",
        data: { id: id },
        success: function (response) {
            if (!response.isSuccess) {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
            }
            else {
                $('#deleteModal').modal('hide');
                table.ajax.reload()
                //    funToastr(true, response.message);
            }
        },
        error: function (error) {
        }
    });
}


function loadAllModifier() {
    var url = "/Modifier/GetAllModifier"

    table = $("#ModifierTbl").DataTable({

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
                "data": "modifierName"
            },
            {
                "data": "price"
            },
            

            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Modifier/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
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

