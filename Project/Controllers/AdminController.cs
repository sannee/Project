using System.Web.Mvc;
using Domain.Logic;
using Domain.Models;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
         var users =   UsersManager.GetAllUsers();
            return View(users);
        }

        public ActionResult CreateUser()
        {
            return View(new UserViewModel());
        }
        
        [HttpPost]
        public ActionResult CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                    UsersManager.CreateUser(model.UserName, model.Password, model.Email, model.RoleId);
                    return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }

        public ActionResult Roles(int Error=0)
        {
            if (Error==1)
            {
                ModelState.AddModelError("", "Невозможно удалить. Роль используется пользователями.");
            }
            if (Error == 2)
            {
                ModelState.AddModelError("", "Вы не можете удалить эту роль, т.к. она используется системой.");
            }

            return View(RolesManager.GetAllRoles());
        }


        [HttpPost]
        public ActionResult RoleEdit(RoleViewModel model)
        {
            if(ModelState.IsValid) 
            {
             RolesManager.ChangeRole(model.RoleId, model.PermissionBrowse, model.PermissionEdit, model.PermissionDelete);
             return RedirectToAction("Roles");
            }
            else
                return View();
        }

        public ActionResult RoleDelete(int id)
        {
          RoleError error =  RolesManager.DeleteRole(id);
            switch (error)
            {
                case RoleError.NoneError: return RedirectToAction("Roles");
                case RoleError.RoleNotExist: return  RedirectToAction("Index", "Error");
                case RoleError.UsersUseRole: return Redirect("/Admin/Roles/?Error=1");
                case RoleError.DefaultRoleError: return Redirect("/Admin/Roles/?Error=2");                  
            }

            return RedirectToAction("Roles");            
        }

        public ActionResult RoleEdit(int id)
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            Role role = RolesManager.GetRole(id);
            if (role != null)
            {
                roleViewModel.RoleId = id;
                roleViewModel.PermissionBrowse = role.Permission.PermissionBrowse;
                roleViewModel.PermissionEdit = role.Permission.PermissionEdit;
                roleViewModel.PermissionDelete = role.Permission.PermissionDelete;
                roleViewModel.PermissionPaths = role.Permission.PermissionPaths;

                return View(roleViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult PathDelete(int id, int RoleId)
        {
            PermissionManager.DeletePermissionPath(id);
            return RedirectToAction("Index", "Admin/RoleEdit/" + RoleId.ToString());
        }



        [HttpPost]
        public ActionResult CreateRole(string RoleName)
        {
            if(!RolesManager.RoleExist(RoleName)){
            Role role = RolesManager.CreateRole(RoleName);
            return RedirectToAction("Index", "Admin/RoleEdit/" + role.RoleId.ToString());
            }
            else
            {
                ModelState.AddModelError("", "Роль с таким именем уже существует!");
                return View();
            }
        }

        public ActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Roles(RoleViewModel model)
        {
            return View(RolesManager.GetAllRoles());
        }

        public ActionResult UserEdit(int id)
        {
            User user = UsersManager.GetUser(id);
            if(user!=null)
            {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.RoleId = user.RoleId;
            userViewModel.UserName = user.Login;
            userViewModel.Email = user.Email;
            userViewModel.UserId = id;
            userViewModel.PreviousUserName = user.Login;
            return View(userViewModel);
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public ActionResult UserEdit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserId >= 0)
                {
                    if (model.UserName != model.PreviousUserName) ;
                    UsersManager.ChangeUser(model.UserId, model.UserName, model.Password, model.Email, model.RoleId);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            UsersManager.DeleteUser(id);
            return RedirectToAction("Index", "Admin");
        }


        public ActionResult PathAdd(string Action, string Controller, int RoleId)
        {
            RolesManager.AddPath(Action, Controller, RoleId);
            return RedirectToAction("Index", "Admin/RoleEdit/"+RoleId.ToString());
        }
    }
}
