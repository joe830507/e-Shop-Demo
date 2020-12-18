using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;
using e_Shop_Demo.Repository;
using e_Shop_Demo.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IDistributedCache DistributedCache { get; }
        public IMapper Mapper { get; }
        public EmployeeController(IRepositoryWrapper wrapper, IMapper mapper, IDistributedCache distributedCache)
        {
            Repository = wrapper;
            Mapper = mapper;
            DistributedCache = distributedCache;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            IEnumerable<Employee> employees = await Repository.Employee.GetAllAsync();
            var result = Mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(result);
        }
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