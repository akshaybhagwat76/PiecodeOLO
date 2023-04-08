

using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    public class UserStaff:BaseEntity
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; } 
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

        [NotMapped]
        public string RolesName { get; set; }
        public string Name { get; set;}

        public string LoginType { get; set; }

        public string DeviceId { get; set; }


    }
}
