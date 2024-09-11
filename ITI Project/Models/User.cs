using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm password is required!")]
        [DisplayName("Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
