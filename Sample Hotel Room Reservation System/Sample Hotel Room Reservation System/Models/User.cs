using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sample_Hotel_Room_Reservation_System.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Password")]
        public string? PasswordHash { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "last Name")]
        public string? LastName { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string? PhysicalAddress { get; set; } = string.Empty;

        public User()
        {
           
        }

        public User(string _username, string _email, string _passwordHash, string _firstname, string _lastname, int _phoneNumber, string physicalAddress)

        {
            UserName = _username;
            Email = _email;
            FirstName = _firstname;
            LastName = _lastname;
            PasswordHash = _passwordHash;
            PhoneNumber = _phoneNumber;
            PhysicalAddress = physicalAddress;
            
        }
    }
}
