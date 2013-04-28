using System.ComponentModel.DataAnnotations;
using Domain.Logic;

namespace Domain.Models
{
    public class RegisterViewModel
    {
        [UserExistError(ErrorMessage = "Такой пользователь уже существует")]
        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверно введен Email")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
