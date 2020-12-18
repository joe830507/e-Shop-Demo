using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using e_Shop_Demo.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpLoginController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public ILogger<EmpLoginController> Logger { get; }
        public IMongoCollection<BsonDocument> Collection { get; set; }

        public EmpLoginController(IRepositoryWrapper wrapper, IMapper mapper, IConfiguration configuration,
                                  ILogger<EmpLoginController> logger,IMongoDbSetting settings)
        {
            Repository = wrapper;
            Mapper = mapper;
            Configuration = configuration;
            Logger = logger;
            var client = new MongoClient(settings.Uri);
            var database = client.GetDatabase(settings.DatabaseName);
            Collection = database.GetCollection<BsonDocument>("myTest");
        }

        [HttpPost(Name = nameof(EmpLoginAsync))]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<object>> EmpLoginAsync([FromBody] EmployeeForLoginDto emp)
        {

            Employee empForCheck = await Repository.Employee.GetEmpByAccount(emp.Account);
            if (empForCheck == null)
                return BadRequest("No account.");
            else if (!empForCheck.Password.Equals(SHA256Utility.Encode(emp.Password)))
                return BadRequest("Wrong password.");
            else if (!empForCheck.Activate)
                return Unauthorized("You should authenticate your account by your email.");
            else
            {
                var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub,emp.Account)
                };
                Logger.LogInformation($"Account:{emp.Account}, Action:EmpLoginAsync.");
                return Ok(this.GetToken(Configuration, claims));
            }
        }
    }
}