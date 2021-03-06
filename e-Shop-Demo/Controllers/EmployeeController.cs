﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Attributes;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Dtos.Employee;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Enums;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
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

        [HttpGet]
        public async Task<ActionResult> GetEmployees([FromQuery] EmployeeResourceParameters parameters)
        {
            IEnumerable<Employee> employees = await Repository.Employee.GetAllAsync(parameters);
            if (employees == null)
                return BadRequest("No Employee");
            else
            {
                var result = Mapper.Map<IEnumerable<EmployeeForDisplayDto>>(employees);
                return Ok(new
                {
                    body = result,
                    pages = this.GetPagination(employees)
                });
            }
        }

        //TODO : Activate by Email
        [HttpPost]
        [RoleValidator(Role.Manager)]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeForCreationDto employee)
        {
            Employee empForCheck = await Repository.Employee.GetEmpByAccount(employee.Account);
            if (empForCheck != null)
                return BadRequest("Your account is duplicate.");
            else
            {
                Employee empForAdd = Mapper.Map<Employee>(employee);
                empForAdd.ID = Guid.NewGuid();
                empForAdd.Password = employee.Password;
                empForAdd.Activate = employee.Activate;
                empForAdd.Role = employee.Role;
                empForAdd.CreateTime = DateTime.Now;
                Repository.Employee.Create(empForAdd);
                if (!await Repository.Employee.SaveAsync())
                    return BadRequest();
                return NoContent();
            }
        }

        [AllowAnonymous]
        [HttpPost("login", Name = nameof(EmpLoginAsync))]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<object>> EmpLoginAsync([FromBody] EmployeeForLoginDto emp)
        {
            Employee empForCheck = await Repository.Employee.GetEmpByAccount(emp.Account);
            if (empForCheck == null)
                return BadRequest("No account.");
            else if (!empForCheck.Password.Equals(emp.Password))
                return BadRequest("Wrong password.");
            else if (!empForCheck.Activate)
                return Unauthorized("You should authenticate your account by your email.");
            else
            {
                var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub,emp.Account),
                    new Claim("role",empForCheck.Role.ToString())
                };
                Logger.LogInformation($"Account:{emp.Account}, Action:EmpLoginAsync.");
                return Ok(this.GetToken(Configuration, claims));
            }
        }

        [AllowAnonymous]
        [HttpPost("logout", Name = nameof(EmpLogoutAsync))]
        public async Task<ActionResult> EmpLogoutAsync([FromHeader(Name = "Authorization")] string authorization)
        {
            string[] splitAuthorization = string.IsNullOrEmpty(authorization) ? null : authorization.Split($" ");
            if (splitAuthorization.Length == 2 && !splitAuthorization.Equals("null"))
            {
                var authorizationArray = splitAuthorization[1].Split($".");
                var jsonString = Encoding.UTF8.GetString(Base64UrlEncoder.DecodeBytes(authorizationArray[1]));
                EmployeeInfoDto empInfo = JsonConvert.DeserializeObject<EmployeeInfoDto>(jsonString);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
                // set the same expiration as JWT
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dateTime = dateTime.AddSeconds(empInfo.Exp).ToLocalTime();
                options.SetAbsoluteExpiration(new DateTimeOffset(dateTime));
                await DistributedCache.SetAsync(splitAuthorization[1], Encoding.UTF8.GetBytes("out"), options);
            }
            return NoContent();
        }

        [HttpPut]
        [RoleValidator(Role.Manager)]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            Employee empForCheck = await Repository.Employee.GetEmpByAccount(employeeForUpdateDto.Account);
            if (empForCheck == null)
                return NotFound();
            empForCheck.UpdateTime = DateTime.Now;
            if (!string.IsNullOrEmpty(employeeForUpdateDto.Password))
                empForCheck.Password = employeeForUpdateDto.Password;
            Repository.Employee.Update(empForCheck);
            if (!await Repository.Employee.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }

        [HttpDelete]
        [RoleValidator(Role.Manager)]
        public async Task<ActionResult> DeleteEmployees([FromBody] EmployeeForDeleteDto employeeForUpdateDto)
        {
            Repository.Employee.DeleteEmployees(employeeForUpdateDto.Employees);
            if (!await Repository.Employee.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }

    }
}