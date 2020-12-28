using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Dtos.Customer;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpGet]
        public async Task<ActionResult> GetCustomers([FromQuery] CustomerResourceParameters parameters)
        {
            IEnumerable<Customer> customers = await Repository.Customer.GetAllAsync(parameters);
            if (customers == null)
                return BadRequest("No Customer");
            else
            {
                var result = Mapper.Map<IEnumerable<CustomerForDisplayDto>>(customers);
                return Ok(new
                {
                    body = result,
                    pages = this.GetPagination(customers)
                });
            }
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

        [HttpPost(Name = nameof(AddCustomer))]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerForCreationDto customerForCreationDto)
        {
            Customer custForCheck = await Repository.Customer.GetCustByAccount(customerForCreationDto.Account);
            if (custForCheck != null)
                return BadRequest("This account has existed.");
            Customer customer = Mapper.Map<Customer>(customerForCreationDto);
            customer.ID = Guid.NewGuid();
            customer.CreateTime = DateTime.Now;
            Repository.Customer.Create(customer);
            if (!await Repository.Customer.SaveAsync())
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomers([FromBody] CustomerForDeleteDto customerForDeleteDto)
        {
            Repository.Customer.DeleteCustomers(customerForDeleteDto.Customers);
            if (!await Repository.Customer.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] CustomerForUpdateDto customerForUpdateDto)
        {
            Customer customer = Mapper.Map<Customer>(customerForUpdateDto);
            if (!await Repository.Customer.IsExistAsync(customer.ID))
                return NotFound();
            if (string.IsNullOrEmpty(customer.Password))
            {
                Customer custForCheck = await Repository.Customer.GetByIdAsync(customer.ID);
                //Detaching custForCheck for updating the modified instance, or invalid operation will occur.
                Repository.Customer.DbContext.Entry(custForCheck).State = EntityState.Detached;
                customer.Password = custForCheck.Password;
            }
            customer.UpdateTime = DateTime.Now;
            Repository.Customer.Update(customer);
            if (!await Repository.Customer.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }
    }
}