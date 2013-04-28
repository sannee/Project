using System.ComponentModel.DataAnnotations;

namespace Domain.Logic
{
    internal class UserExistError : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
                var login = value as string;
            if (UsersManager.UserAlreadyExists(login))
                return false;
            else return true;

        }

    }
}
