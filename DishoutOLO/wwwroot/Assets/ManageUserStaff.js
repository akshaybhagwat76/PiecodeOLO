$(document).ready(function () {
    $("#lblError").removeClass("success").removeClass("error").text('');



    var id = $("#Id").val();
    if (id == 0) {
        $("#DateOfBirth").val("");
        $("#JoiningDate").val("");
        $("#LicenseExpiration").val("");

    }

        $("#btn-Add").on("click", function () {
        $("#lblError").removeClass("success").removeClass("error").text('');
        var retval = true;
        $("#myForm .required").each(function () {
            if (!$(this).val()) {
                $(this).addClass("error");
                retval = false;
            }
            else {
                $(this).removeClass("error");
            }
        });
        if (retval) {
            var data = {
                id: $("#Id").val(),
                UserName: $("#UserName").val(),
                Email: $("#Email").val(),
                Password: $("#Password").val(),
                RoleId: $("#RoleId").val(),
                Phonenumber: $("#Phonenumber").val(),
                DateOfBirth: $("#DateOfBirth").val(),
                JoiningDate: $("#JoiningDate").val(),
                LicenseExpiration: $("#LicenseExpiration").val(),
                State: $("#State").val(),
                City: $("#City").val(),
                ZipCode: $("#ZipCode").val(),
                Street: $("#Street").val(),
                LicensePlate: $("#LicensePlate").val(),
                DriverLicenseNumber: $("#DriverLicenseNumber").val(),
                ContactInfo: $("#ContactInfo").val(),
                VehicleTypeId: $("#VehicleTypeId").val(),
                Name: $("#Name").val(),
                LoginType: $("#LoginType").val(),
                DeviceId: $("#DeviceId").val(),
               IsActive: $("#IsActive").val() == "true" ? true : false
            }
            $.ajax({
                type: "POST",
                url: "/UserStaff/AddOrUpdateUserStaff",
                data: { UserStaffVM: data },
                success: function (data) {
                    if (!data.isSuccess) {
                        $("#lblError").addClass("error").text(data.errors[0].errorDescription).show();

                    }
                    else {
                        window.location.href = '/UserStaff/Index'
                    }
                }
            });
        }

    })


});

$(function () {
    var availableStates = [
        "Gujarat",
        "Maharastra",
        "Andhra Pradesh",
        "Arunachal Pradesh",
        "Bihar",
        "Kerala ",
        "Sikkim",
        "Odisha",
        "Mizoram",
        "Uttarakhand",
        "Karnataka",
        "Tripura",
        "Chhattisgarh",
        "Madhya Pradesh",
        "Himachal Pradesh",
        "Manipur",
        "Goa",
        "Uttar Pradesh",
        "Punjab",
        "Jharkhand"
       
    ];
    $("#State").autocomplete({
        source: availableStates
    });
});     



$(document).ready(function () {
    
    $(function () {
        $("#JoiningDate").datepicker({
            format: 'DD-MM-YYYY',

        });
    });
    $(function () {
        $("#DateOfBirth").datepicker({
            format: 'DD-MM-YYYY',

        });
    });
    $(function () {
        $("#LicenseExpiration").datepicker({
            format: 'DD-MM-YYYY',

        });
    });

})
