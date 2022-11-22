using System.ComponentModel.DataAnnotations;

namespace AspApplication.Domain.Entity
{
    public class Contact
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле фамилии")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
        [Display(Prompt = "Введите фамилию")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Заполните поле имени")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
        [Display(Prompt = "Введите имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Заполните поле отчества")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
        [Display(Prompt = "Введите отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Заполните поле номера телефона")]
        [Display(Prompt = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Prompt = "Введите адрес")]
        public string Addres { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Display(Prompt = "Введите описание")]
        public string Description { get; set; } 

    }
}
