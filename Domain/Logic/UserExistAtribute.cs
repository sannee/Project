using System.ComponentModel.DataAnnotations;
using Domain.Logic;

namespace Domain.Models
{
    class UserExistAtribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var user = value as UserViewModel;
            if (user.UserId > 0)
            {
                var userTo = UsersManager.GetUser(user.UserId);
                if (user.UserName == userTo.Login) return true;
                else
                    return !UsersManager.UserAlreadyExists(user.UserName);
            }
            else
            {
                return !UsersManager.UserAlreadyExists(user.UserName);
            }
        }
    }
}
