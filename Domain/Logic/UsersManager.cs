using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Helpers;

namespace Domain.Logic
{
    public static class UsersManager
    {
        public static User CreateUser(string login, string password, string email)
        {
            try
            {

                var db = new DatabaseEntities();
                var user = new User();

                user.Login = login;
                user.Password = Helper.GetMd5HashString(password);
                user.Email = email;

//                user.Role = new Role();
                
                var role = from r in db.Roles where r.RoleName=="Registered" select r;

                user.Role = role.First();
                db.Users.Add(user);
                db.SaveChanges();
                return user;

            }
            catch
            {
                return null;
            }

        }

        public static User CreateUser(string login, string password,string email, int RoleId)
        {
            var db = new DatabaseEntities();
            var user = new User();

            user.Login = login;
            user.Password = Helper.GetMd5HashString(password);
            user.Email = email;

            //                user.Role = new Role();

            var role = from r in db.Roles where r.RoleId == RoleId select r;

            user.Role = role.First();
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }


        public static bool UserAlreadyExists(string login)
        {
            var db = new DatabaseEntities();
            var query = from user in db.Users where user.Login == login select user.Login;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User ValidateUser(string login, string password)
        {
            var db = new DatabaseEntities();
            string md5PasswordHash = Helper.GetMd5HashString(password);
            var query = from user in db.Users where user.Login == login && user.Password== md5PasswordHash select user;
            if (query.Any())
            {
                return query.First();
            }
            else
            { 
                return null;
            }
        }

        public static User ChangeUser(int id, string login, string password, string email, int roleId)
        {
            var db = new DatabaseEntities();
            var users = from user in db.Users where user.UserId == id select user;
            User u = users.First();
            u.Login = login;
            u.Password = Helper.GetMd5HashString(password);
            u.Email = email;
            u.RoleId = roleId;
            db.SaveChanges();
            return GetUser(id);
        }

        public static User GetUser(int id)
        {
            var db = new DatabaseEntities();
       
            var users = from user in db.Users  where user.UserId==id select user;
            if(users.Any())
            return users.First();
            else return null;
        }

        public static List<User> GetAllUsers()
        {
            var db = new DatabaseEntities();
            var users = from user in db.Users select user;
            return users.ToList();
        }

        public static void DeleteUser(int id)
        {
            var db = new DatabaseEntities();
            var users = from user in db.Users where user.UserId==id select user;
            User u = users.First();
            db.Users.Remove(u);
            db.SaveChanges();
        }


    }
}
