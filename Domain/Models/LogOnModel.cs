using System.ComponentModel.DataAnnotations;


namespace Domain.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
