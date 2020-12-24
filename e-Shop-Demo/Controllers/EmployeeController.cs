using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.IRepository;
using e_Shop_Demo.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IDistributedCache DistributedCache { get; }
        public IMapper Mapper { get; }
        public ILogger<EmployeeController> Logger { get; }
        public EmployeeController(IRepositoryWrapper wrapper, IMapper mapper, IDistributedCache distributedCache,
            IConfiguration configuration, ILogger<EmployeeController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            DistributedCache = distributedCache;
            Configuration = configuration;
            Logger = logger;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        //{
        //    IEnumerable<Employee> employees = await Repository.Employee.GetAllAsync();
        //    var result = Mapper.Map<IEnumerable<EmployeeDto>>(employees);
        //    return Ok(result);
        //}
        //TODO : Activate by Email
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeForCreationDto employee)
        {
            Employee empForCheck = await Repository.Employee.GetEmpByAccount(employee.Account);
            if (empForCheck != null)
                return BadRequest("Your account is duplicate.");
            else
            {
                Employee empForAdd = Mapper.Map<Employee>(employee);
                empForAdd.ID = Guid.NewGuid();
                empForAdd.Password = SHA256Utility.Encode(employee.Password);
                empForAdd.Activate = true;
                Repository.Employee.Create(empForAdd);
                if (await Repository.Employee.SaveAsync())
                    return NoContent();
                else
                    return BadRequest();
            }
        }

        [HttpPost("login", Name = nameof(EmpLoginAsync))]
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

        [HttpPatch]
        public async Task<ActionResult> PartiallyUpdateEmployee([FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            Employee empForCheck = await Repository.Employee.GetEmpByAccount(employeeForUpdateDto.Account);
            if (empForCheck == null)
                return NotFound();
            JsonPatchDocument<Employee> jsonPatch = new JsonPatchDocument<Employee>();
            jsonPatch.Replace(e => e.Password, SHA256Utility.Encode(employeeForUpdateDto.Password));
            jsonPatch.ApplyTo(empForCheck, ModelState);
            Repository.Employee.Update(empForCheck);
            if (!ModelState.IsValid || !await Repository.Employee.SaveAsync())
                return BadRequest(ModelState);
            return Ok();
        }
    }
}