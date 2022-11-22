using System.ComponentModel.DataAnnotations;

namespace AspApplication.Domain.ViewModels
{
    public class UserRegistration
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
