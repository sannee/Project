using System.Web.Mvc;
using Domain.Models;
using Domain.Logic;

namespace Project.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UsersManager.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    Session.Clear();
                    Session.Add("Permission", user.Role.Permission);
                    Session.Add("DeleteEntities", user.Role.Permission.PermissionDelete);
                    Session.Add("EditEntities", user.Role.Permission.PermissionEdit);
                    Session.Add("CreateEntities", user.Role.Permission.PermissionBrowse);

                    Session.Add("Username", user.Login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                   ModelState.AddModelError("", "Такой комбинации логин/пароль не найдено");
                }
            }
            return View(model);
        }


        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (Request.IsAuthenticated) return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                if (!UsersManager.UserAlreadyExists(model.UserName))
                {
                    var user = UsersManager.CreateUser(model.UserName, model.Password, model.Email);
                    if (user != null)
                    {
                        Session.Clear();
                        Session.Add("DeleteEntities", user.Role.Permission.PermissionDelete);
                        Session.Add("EditEntities", user.Role.Permission.PermissionEdit);
                        Session.Add("CreateEntities", user.Role.Permission.PermissionBrowse);
                        Session.Add("Permission", user.Role.Permission);
                        Session.Add("Username", user.Login);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "По каким-то причинам регистрация не выполнена, попробуйте еще раз");
                }
                else
                {
                     ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

    }
}
