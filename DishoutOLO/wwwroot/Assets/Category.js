var table,id=0;
$("document").ready(function () {
    loadAllCategory();

   
})





$("#categoryTbl").on("click", "a#btn-delete", function () {
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
            deleteCategory();
            toastr.success('Record Deleted Successfully.')

        }
    })
});

function deleteCategory() {
    $.ajax({
        type: "GET",
        url: "/Category/DeleteCategory",
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


function loadAllCategory() {
    var url = "/Category/GetAllCategory"
   
    table = $("#categoryTbl").DataTable({
        
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
                "data": "categoryName"
            },
            {
                "data": function (show) {
                    if (show.status == true) {
                        return "Active";
                    }
                    else {
                        return "Deactive";
                    }
                }
            },
            
            
            {
                orderable: false ,
                "render":function(data,type,full,meta) {
                    return ` <a href="/Category/Edit/` + full.id + `" data-id="` + full.id + `" class="btn btn-success btn-sm" title="Edit">
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

