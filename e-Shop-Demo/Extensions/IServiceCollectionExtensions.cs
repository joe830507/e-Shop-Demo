using e_Shop_Demo.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMyMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSetting>(configuration.GetSection("MongoDBConnection"));
            services.AddSingleton<IMongoDbSetting>(x => x.GetRequiredService<IOptions<MongoDbSetting>>().Value);
        }
    }
}
