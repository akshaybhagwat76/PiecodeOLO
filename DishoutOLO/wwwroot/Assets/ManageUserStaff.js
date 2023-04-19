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
            ZipCode: 'short_name',
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
$(function () {
    
    var lat = 44.88623409320778,
        lng = -87.86480712897173,
        latlng = new google.maps.LatLng(),
        image = '';

    var mapOptions = {
        center: new google.maps.LatLng(lat, lng),
        zoom: 13,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        panControl: true,
        panControlOptions: {
            position: google.maps.ControlPosition.TOP_RIGHT
        },
        zoomControl: true,
        zoomControlOptions: {
            style: google.maps.ZoomControlStyle.LARGE,
            position: google.maps.ControlPosition.TOP_left
        }
    },
        map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions),
        marker = new google.maps.Marker({
            position: latlng,
            map: map,
            icon: image,
            draggable: true
        });

    var input = document.getElementById('Street');
    var autocomplete = new google.maps.places.Autocomplete(input, {
        types: ["geocode"]
    });

    autocomplete.bindTo('bounds', map);
    var infowindow = new google.maps.InfoWindow();

    google.maps.event.addListener(autocomplete, 'place_changed', function (event) {
        infowindow.close();
        var place = autocomplete.getPlace();
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);
        }

        moveMarker(place.name, place.geometry.location);
             
    });
    google.maps.event.addListener(marker, 'dragend', function (event) {
              
    });
    $("#Street").focusin(function () {
        $(document).keypress(function (e) {
            if (e.which == 13) {
                return false;
                infowindow.close();
                var firstResult = $(".pac-container .pac-item:first").text();
                var geocoder = new google.maps.Geocoder();
                geocoder.geocode({
                    "address": firstResult
                }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        var lat = results[0].geometry.location.lat(),
                            lng = results[0].geometry.location.lng(),
                            placeName = results[0].address_components[0].long_name,
                            latlng = new google.maps.LatLng(lat, lng);

                        moveMarker(placeName, latlng);
                        $("input").val(firstResult);
                        alert(firstResult)
                    }
                });
            }
        });
    });

    function moveMarker(placeName, latlng) {
        marker.setIcon(image);
        marker.setPosition(latlng);
        infowindow.setContent(placeName);
        //infowindow.open(map, marker);
    }
});













