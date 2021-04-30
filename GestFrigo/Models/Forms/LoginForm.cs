using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestFrigo.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        [DisplayName("Password")]
        public string Passwd { get; set; }
    }
}