var table,id=0;
$("document").ready(function () {
    loadAllArticles();

});
$("#articleTbl").on("click", "a#btn-delete", function () {
    var aid = $(this).data('id');
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
            id = aid
            deleteArticle();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteArticle() {
    $.ajax({
        type: "GET",
        url: "/Article/DeleteArticle",
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





function loadAllArticles() {
    
    var url = "/Article/GetAllArticle"
    table = $("#articleTbl").DataTable({

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
                "data": "articleName"
            },

            {
                orderable: false,
                "render": function (data, type, full, meta) {
                    return ` <a href="/Article/Edit/` + full.id + `" data-id="` + full.id + `"  class="btn btn-success btn-sm" title="Edit">
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

