using e_Shop_Demo.Attributes;
using e_Shop_Demo.Dtos.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace e_Shop_Demo.Middlewares
{
    public class RoleValidatorMiddleware
    {
        public RequestDelegate _next { get; }
        public RoleValidatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var authorization = httpContext.Request.Headers[HeaderNames.Authorization].ToString();
                EmployeeInfoDto empInfo = GetAuthorization(authorization);
                var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                var attribute = endpoint?.Metadata.GetMetadata<RoleValidatorAttribute>();
                if (attribute != null && empInfo != null)
                {
                    var _role = (int)attribute.Role;
                    var empRole = (int)empInfo.Role;
                    if (empRole > _role)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await httpContext.Response.WriteAsync("You are unauthorizated to use this function.");
                    }
                }
                await _next(httpContext);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public EmployeeInfoDto GetAuthorization(string authorization)
        {
            string[] splitAuthorization = string.IsNullOrEmpty(authorization) ? null : authorization.Split($".");
            if (splitAuthorization == null)
                return null;
            var base64String = splitAuthorization.Length == 3 ? splitAuthorization[1] : null;
            if (base64String == null)
                return null;
            var jsonString = Encoding.UTF8.GetString(Base64UrlEncoder.DecodeBytes(base64String));
            return JsonConvert.DeserializeObject<EmployeeInfoDto>(jsonString);
        }
    }
}
