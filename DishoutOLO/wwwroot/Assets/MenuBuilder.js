var table;
$("document").ready(function () {
    loadAllMenuBuilder();
});




function loadAllMenuBuilder() {

    var url = "/MenuBuilder/GetAllMenuBuilder"


    //table = $("#menubuilderTbl").DataTable({

    //    "serverSide": true,
    //    "bFilter": true,
    //    "orderMulti": false,
    //    "ajax": {
    //        url: url,
    //        type: "POST",
    //        datatype: "json"
    //    },

    //    "columns": [
    //        {
    //            "data": "menuName"
    //        },
    //        {
    //            "data": "descrition"
    //        },
    //        {
    //            "data": "week"
    //        },
    //        {
    //            "data": "fullTime"
    //        },

    //    ],

   

    debugger;
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (response) {
            console.log("Test", response);

            $("#card").html('');
            var div3Content = '';
            for (var i = 0; i < response.length; i++) {
                div3Content += '<card>' + response[i].Name + '</card>' + '<p>'
            }
            $("#card").append(div3Content);
        }
    });   

}
