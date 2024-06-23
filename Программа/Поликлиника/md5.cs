using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Приложушечка

{
    public static class MD5Gen
    {
        public static string MD5Hash(string input) //md5 converter for pwords
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}


// class md5 
// {
//       public static string hashPassword(string password)
//      {
//         MD5 md5 = MD5.Create();

//        byte[] b =  Encoding.ASCII.GetBytes(password);
//        byte[] hash = md5.ComputeHash(b);

//        StringBuilder sb = new StringBuilder();
//       foreach (var a in hash)
//           sb.Append(a.ToString(a.ToString("X2")));
//
//       return Convert.ToString(sb);
//      }
//  }

//}
