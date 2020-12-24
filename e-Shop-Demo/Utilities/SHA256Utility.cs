using System;
using System.Security.Cryptography;
using System.Text;

namespace e_Shop_Demo.Utilities
{
    public class SHA256Utility
    {
        public static string Encode(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] computedData = sha256.ComputeHash(data);
            return Convert.ToBase64String(computedData);
        }
    }
}
