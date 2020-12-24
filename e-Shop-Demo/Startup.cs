using AutoMapper;
using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;
using e_Shop_Demo.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using e_Shop_Demo.Filters;
using e_Shop_Demo.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace e_Shop_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(config =>
            {
                config.Filters.Add<JsonExceptionFilter>();
            });
            services.AddControllers();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            //---------------------Identity
            services.AddIdentity<Employee, Role>().AddEntityFrameworkStores<LibraryDbContext>();
            //---------------------Authentication
            var securityToken = Configuration.GetSection("Security:Token");
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = securityToken["Issuer"],
                            ValidAudience = securityToken["Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityToken["Key"])),
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            //---------------------Redis Cache
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["RedisCache:Host"];
                options.InstanceName = Configuration["RedisCache:Instance"];
            });
            //---------------------Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            //---------------------MongoDB
            services.AddMyMongoDB(Configuration);
            //---------------------Cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());

            app.UseMyNLog(Configuration);

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
