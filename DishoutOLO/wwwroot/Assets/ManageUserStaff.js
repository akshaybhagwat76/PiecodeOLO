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
$(document).ready(function () {
    
    $(".dtpicker").datepicker({
            format: 'DD-MM-YYYY'
    });
        
    $("#DateOfBirth").datepicker({
        onSelect: function (value, ui) {
            var current = new Date().getTime(),
                dateSelect = new Date(value).getTime();
            age = current - dateSelect;
            ageGet = Math.floor(age / 1000 / 60 / 60 / 24 / 365.25);
            if (ageGet < 18) {
                less_than_18(ageGet);
            } else {
                greater_than_18(ageGet);
            }
        },
        yearRange: '1900:+0d',
        changeMonth: true,
        changeYear: true,
        defaultDate: '-18yr',
    }).attr("readonly", "readonly"); 


    function less_than_18(theAge) {
        toastr.success("Failed! your age is less than 18. Age: " + theAge);
    }


    
    var auto;
    var input = "Street";
    auto = new google.maps.places.Autocomplete((document.getElementById(input)), {
        types: ['geocode']
    })

    google.maps.event.addListener(auto, 'place_changed', function () {
        var place = auto.getPlace();
        var componentForm = {
            street_number: 'short_name',
            route: 'long_name',
            locality: 'long_name',
            administrative_area_level_1: 'short_name',
            ZipCode: 'long_name',
            postal_code: 'short_name'
        };
        if (place.address_components) {
            for (const comment of place.address_components) {
                const addressType = comment.types[0];
                const val = comment[componentForm[addressType]];
                if (componentForm[addressType]) {
                    if (addressType === 'postal_code') {
                        $("#ZipCode").val(val);
                    } else if (addressType === 'administrative_area_level_1') {
                        $("#State").val(comment.long_name);


                    } else if (addressType === 'locality') {
                        $("#City").val(comment.long_name);

                    }
                    if (addressType && addressType === 'ZipCode') {
                        console.log('ZipCode' + comment.long_name);

                    }
                }
            }
        }
    });
})

