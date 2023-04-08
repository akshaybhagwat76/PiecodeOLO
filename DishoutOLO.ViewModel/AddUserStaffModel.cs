using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddUserStaffModel
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public string RolesName { get; set; }
        [DisplayName("Phone Number")]
        public string Phonenumber { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }

        [DisplayName("License Expiration")]
        public DateTime LicenseExpiration { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string Street { get; set; }
        [DisplayName("License Plate")]
        public string LicensePlate { get; set; }
        
        [DisplayName("Driver License Number")]
        public string DriverLicenseNumber { get; set; }

        [DisplayName("Contact Info")]
        public string ContactInfo { get; set; }
        [DisplayName("Vehicle Type Id")]
        public string VehicleTypeId { get; set; }


        public string Name { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Login Type")]
       public string LoginType { get; set; }
        [DisplayName("Device Id")]
        public string DeviceId { get; set; }
    }

    public class UpdateUserStaffModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Phonenumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string LicensePlate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string ContactInfo { get; set; }

        public string VehicleTypeId { get; set; }

        public int RoleId { get; set; }
        public string RolesName { get; set; }

        public string Name { get; set; }

        public string LoginType { get; set; }

        public bool IsActive { get; set; }
        public string DeviceId { get; set; }
    }

    public class ListUserStaffModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Phonenumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public int RoleId { get; set; }
        public string RolesName { get; set; }

        public bool IsActive { get; set; }

        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string LicensePlate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string ContactInfo { get; set; }

        public string VehicleTypeId { get; set; }


        public string Name { get; set; }

        public string LoginType { get; set; }

        public string DeviceId { get; set; }
    }

    public class DeleteUserStaffModel 
    {
    
        public int Id { get; set; } 
    }
}
