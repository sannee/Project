using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Models;

namespace Domain.Logic
{
    public static class PermissionManager
    {
        public static bool ValidatePermissions(string controller, string action,  ActionExecutingContext filterContext )
        {
            var permission = filterContext.HttpContext.Session["Permission"] as Permission;
            if (permission == null)
            {
                var db = new DatabaseEntities();
                var p = from guest in db.Roles where guest.RoleName == "Guest" select guest.Permission;
                permission = p.First();
                filterContext.HttpContext.Session.Add("Permission", permission);
                filterContext.HttpContext.Session.Add("DeleteEntities", permission.PermissionDelete);
                filterContext.HttpContext.Session.Add("EditEntities", permission.PermissionEdit);
                filterContext.HttpContext.Session.Add("CreateEntities", permission.PermissionBrowse);

            }

            if (permission.PermissionBrowse == false && controller == "Admin" && action == "CreateUser") return false;
            if (permission.PermissionBrowse == false && controller == "Admin" && action == "CreateRole") return false;

            if (permission.PermissionEdit== false && controller == "Admin" && action == "UserEdit") return false;
            if (permission.PermissionEdit == false && controller == "Admin" && action == "RoleEdit") return false;
            if (permission.PermissionEdit == false && controller == "Admin" && action == "PathAdd") return false;

            if (permission.PermissionDelete == false && controller == "Admin" && action == "DeleteUser") return false;
            if (permission.PermissionDelete == false && controller == "Admin" && action == "RoleDelete") return false;


           var paths = from path in permission.PermissionPaths
                        where path.Controller == controller && path.Action == action 
                            select path;

           
            if (!paths.Any())
            {
                var p = from path in permission.PermissionPaths
                            where path.Controller == controller && path.Action == string.Empty
                            select path;
                return !p.Any();
            }
            else
            {
                return false;
            }

        }

        public static List<Permission> GetAllPermissions()
        {
            var db = new DatabaseEntities();
            var p = from permission in db.Permissions select permission;
            if (p.Any())

                return p.ToList();
            else
            {
                return null;
            }
        }

        public static void DeletePermissionPath(int PathId)
        {
            var db = new DatabaseEntities();
            var p = from permissionPath in db.PermissionPaths where permissionPath.Id==PathId select permissionPath;
            if (p.Any())
            {
                var path = p.First();
                db.PermissionPaths.Remove(path);
                db.SaveChanges();
            }


        }

    }
    }

