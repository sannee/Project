using System.ComponentModel.DataAnnotations;

namespace Domain.Logic
{
    internal class RoleNotExistValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int id = (int)value;

            if (RolesManager.GetRole(id)==null)
                return false;
            else return true;

        }

    }
}
