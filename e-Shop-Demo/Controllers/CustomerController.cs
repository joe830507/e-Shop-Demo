using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public ILogger<CustomerController> Logger { get; }
        public CustomerController(IRepositoryWrapper wrapper, IMapper mapper, IConfiguration configuration,
                                  ILogger<CustomerController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            Logger = logger;
            Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login", Name = nameof(CustLoginAsync))]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<object>> CustLoginAsync([FromBody] CustomerForLoginDto cust)
        {
            Customer custForCheck = await Repository.Customer.GetCustByAccount(cust.Account);
            if (custForCheck == null)
                return BadRequest("No account.");
            else if (!custForCheck.Password.Equals(cust.Password))
                return BadRequest("Wrong password.");
            else if (!custForCheck.Activate)
                return Unauthorized("You should authenticate your account by your email.");
            else
            {
                var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub,cust.Account)
                };
                Logger.LogInformation($"Account:{cust.Account}, Action:CustLoginAsync.");
                return Ok(this.GetToken(Configuration, claims));
            }
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(CustRegisterAsync))]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<object>> CustRegisterAsync([FromBody] CustomerForLoginDto cust)
        {
            return null;
        }
    }
}