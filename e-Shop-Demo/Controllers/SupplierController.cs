using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Dtos.Supplier;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IDistributedCache DistributedCache { get; }
        public IMapper Mapper { get; }
        public ILogger<SupplierController> Logger { get; }
        public SupplierController(IRepositoryWrapper wrapper, IMapper mapper, IDistributedCache distributedCache,
            IConfiguration configuration, ILogger<SupplierController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            DistributedCache = distributedCache;
            Configuration = configuration;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetSuppliers([FromQuery] SupplierResourceParameters parameters)
        {
            IEnumerable<Supplier> suppliers = await Repository.Supplier.GetAllAsync(parameters);
            if (suppliers == null)
                return BadRequest("No Supplier");
            else
            {
                var result = Mapper.Map<IEnumerable<SupplierForDisplayDto>>(suppliers);
                return Ok(new
                {
                    body = result,
                    pages = this.GetPagination(suppliers)
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplier([FromBody] SupplierForCreationDto supplierDto)
        {
            IEnumerable<Supplier> suppliers = await Repository.Supplier.GetByConditionAsync(s => s.Name.Equals(supplierDto.Name) ||
                                                    s.Phone.Equals(supplierDto.Phone), null);
            if (suppliers.Count() > 0)
                return BadRequest("Your supplier is existed.");
            Supplier supplier = Mapper.Map<Supplier>(supplierDto);
            supplier.ID = Guid.NewGuid();
            supplier.CreateTime = DateTime.Now;
            Repository.Supplier.Create(supplier);
            if (!await Repository.Supplier.SaveAsync())
                return BadRequest();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSupplier([FromBody] SupplierForUpdateDto supplierForUpdateDto)
        {
            Supplier supplier = Mapper.Map<Supplier>(supplierForUpdateDto);
            if (!await Repository.Supplier.IsExistAsync(supplier.ID))
                return NotFound();
            supplier.UpdateTime = DateTime.Now;
            Repository.Supplier.Update(supplier);
            if (!await Repository.Supplier.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSuppliers([FromBody] SupplierForDeleteDto supplierForDeleteDto)
        {
            Repository.Supplier.DeleteSuppliers(supplierForDeleteDto.Suppliers);
            if (!await Repository.Supplier.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }
    }
}