using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Logic;

namespace Domain.Models
{
   public class RoleViewModel
    {
       [Required]
       [RoleNotExistValidation(ErrorMessage = "Роль, которую вы пытаетесь отредактировать, не существует")]
       public int RoleId { get; set; }

       [Display(Name = "Разрешить создавать записи")]
       [Required]
       public bool PermissionBrowse { set; get; }

       [Required]
       [Display(Name = "Разрешить редактровать записи")]       
       public bool PermissionEdit { set; get; }

       [Required]
       [Display(Name = "Разрешить удалять записи")]         
       public bool PermissionDelete { set; get; }

       public ICollection<PermissionPath> PermissionPaths { get; set; }
    }
}
