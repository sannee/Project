using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
   static class Helper
    {
        public static string GetMd5HashString(string password)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(bytes);
            string str = "";
            byte[] numArray = hash;

            for(int i = 0; i < numArray.Length; i++)
            {
                byte num = numArray[i];
                str = str + num.ToString("x2");
            }
            return str;
        }
    }
}
