    var table;
    $("document").ready(function () {
        loadAllOrder();
    });




    function loadAllOrder() {

        var url = "/Order/GetAllOrder"
        table = $("#orderTbl").DataTable({

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
                    "data": "menuId"
                },
                {
                    "data": "customerId"
                },
                {
                    "data": "orderId"
                },
                {
                    "data": "orderdate",
                    "render": function (data) {
                        var date = new Date(data);
                        var month = date.getMonth() + 1;
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();

                    }
                },
            
            

            ],

        });



    }
