using GestFrigo.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestFrigo.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [EmailNotExists]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        [DisplayName("Password")]
        public string Passwd { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Passwd))]
        [DisplayName("Confirm Password")]
        public string Verification { get; set; }
    }
}