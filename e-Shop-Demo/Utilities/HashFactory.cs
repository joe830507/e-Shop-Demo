using Newtonsoft.Json;
using System.Text;

namespace e_Shop_Demo.Utilities
{
    public class HashFactory
    {
        public static string GetHash(object entity)
        {
            string result = string.Empty;
            string json = JsonConvert.SerializeObject(entity);
            var bytes = Encoding.UTF8.GetBytes(json);
            return null;
        }
    }
}
