﻿var table;
$("document").ready(function () {
    loadAllItemgroup();
    


})
$("#itemgroupTbl").on("click", "a#btn-delete", function () {
    var id = $(this).data('id');
    $('#deleteModal').data('id', id).modal('show');
    $('#deleteModal').modal('show');
});



$('#delete-btn').click(function () {
    var id = $('#deleteModal').data('id');
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
                //    funToastr(true, response.message);
            }
        },
        error: function (error) {
        }
    });
});


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

