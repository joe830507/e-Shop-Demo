using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Helpers
{
    public interface IMongoDbSetting
    {
        public string Uri { get; set; }
        public string DatabaseName { get; set; }
    }
}
