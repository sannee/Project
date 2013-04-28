using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain.Logic
{
        public enum RoleError
        {
            UsersUseRole=0x01,
            RoleNotExist =0x02,
            NoneError=0x03,
            DefaultRoleError=0x04 
        }

    public static class RolesManager
    {


        public static List<Role> GetAllRoles()
        {
            var db = new DatabaseEntities();
            var query = from role in db.Roles select role;
            if (query.Any())
            {
                return query.ToList();
            }
            else
            {
                return null;
            }
        }

        
        public static Role GetRole(int RoleId)
        {
            var db = new DatabaseEntities();
            var r = from role in db.Roles where role.RoleId == RoleId select role;
            if (r.Any())
            {
                return r.First();
            }
            else
            {
                return null;
            }
        }

        public static Role AddPath(string Action, string Controller, int RoleId)
        {
            var db = new DatabaseEntities();
            var r = from role in db.Roles where role.RoleId == RoleId select role;
            if (r.Any())
            {
                var role = r.First();
                PermissionPath path = new PermissionPath();
                path.Action = Action;
                path.Controller = Controller;
                role.Permission.PermissionPaths.Add(path);
                db.SaveChanges();
                return role;
            }
            else
            {
                return null;
            }
        }

        public static Role CreateRole(string RoleName,int PermissionId)
        {
            var db = new DatabaseEntities();
            var p = from permission in db.Permissions where permission.PermissionId == PermissionId select permission;

            if (p.Any())
            {
                Role role = new Role();
                role.Permission = p.First();
                role.RoleName = RoleName;
                db.Roles.Add(role);
                db.SaveChanges();
                return role;
            }
            else
            {
                return null;
            }
        }

        public static Role CreateRole(string RoleName)
        {
                var db = new DatabaseEntities();
                Role role = new Role();
                role.Permission = new Permission();
                role.RoleName = RoleName;
                db.Roles.Add(role);
                db.SaveChanges();
                return role;
            }


        public static RoleError DeleteRole(int id)
        {
            var db = new DatabaseEntities();
            var roles = from role in db.Roles where role.RoleId == id select role;
            if (roles.Any())
            {
                var role = roles.First();
                if (role.RoleName == "Guest" || role.RoleName == "Registered" || role.RoleName == "Administrators")
                return RoleError.DefaultRoleError;
            }

            var users = from user in db.Users where user.RoleId==id select user;
            if (users.Any())
            {
                return RoleError.UsersUseRole;
            }
            else
            {
                var r = from role in db.Roles where role.RoleId == id select role;

                if (r.Any())
                {
                    var role = r.First();
                    var permissions = from p in db.Permissions where p.PermissionId == role.PermissionId select p;
                    Permission permission = permissions.First();
                    db.Roles.Remove(role);
                    db.Permissions.Remove(permission);
                    var paths = from path in db.PermissionPaths where path.PermissionId== role.PermissionId select path;

                    if (paths.Any())
                    {
                        var pathsList = paths.ToList();
                        foreach (var path in pathsList)
                        {
                            db.PermissionPaths.Remove(path);
                        }
                    }

                    db.SaveChanges();
                    return RoleError.NoneError;
                }
                else return RoleError.RoleNotExist;
            }
        }

        public static bool RoleExist(string roleName)
        {
            var db = new DatabaseEntities();
            var r = from role in db.Roles where role.RoleName== roleName select role;
            return r.Any();
        }

        public static Role ChangeRole(int roleId, bool browse, bool edit, bool delete)
        {
            var db = new DatabaseEntities();
            var r = from role in db.Roles where role.RoleId == roleId select role;
            if (r.Any())
            {
                Role role = r.First();
                role.Permission.PermissionBrowse = browse;
                role.Permission.PermissionEdit = edit;
                role.Permission.PermissionDelete = delete;
                db.SaveChanges();
                return role;
            }
            else
            {
                return null;
            }

        }


    }
}
