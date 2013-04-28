using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Logic;

namespace Domain.Models
{
    [UserExistAtribute(ErrorMessage = "Такой пользователь уже существует")]
    public class UserViewModel
    {
        private List<Role> _roles;
        private int _userId = -1;

        public int UserId {
            get { return _userId; }
            set { _userId = value; }
        }
        public string PreviousUserName { get; set; } 

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Неверно введен Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательное для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RoleNotExistValidation]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public SelectList UserRoles
        {
            get { return new SelectList(RolesManager.GetAllRoles(), "RoleId", "RoleName"); }
        }

        /*
        public Role RoleId { get; set; }

        public IEnumerable<SelectListItem> UserRoles
        {
            get
            {
                return RolesManager.GetAllRoles().Select(t => new SelectListItem
                {
                    Text = t.RoleName,
                    Value = t.RoleId.ToString()
                });
            }
        }
         */
    }
}
