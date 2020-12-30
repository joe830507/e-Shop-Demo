using AutoMapper;
using e_Shop_Demo.Dtos.ImportRecord;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
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
    public class ImportRecordController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IDistributedCache DistributedCache { get; }
        public IMapper Mapper { get; }
        public ILogger<ImportRecordController> Logger { get; }
        public ImportRecordController(IRepositoryWrapper wrapper, IMapper mapper, IDistributedCache distributedCache,
            IConfiguration configuration, ILogger<ImportRecordController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            DistributedCache = distributedCache;
            Configuration = configuration;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetImportRecords([FromQuery] ImportRecordResourceParameters parameters)
        {
            IEnumerable<ImportRecord> importRecords = parameters.SupplierID == null ?
                await Repository.ImportRecord.GetAllAsync(parameters) :
                await Repository.ImportRecord.GetByConditionAsync(e => e.SupplierID.ToString().Equals(parameters.SupplierID), parameters);
            if (importRecords == null)
                return BadRequest("No Customer");
            else
            {
                var productIds = (from s in importRecords.ToArray()
                                  select s.ProductID).ToList();
                var result = Mapper.Map<IEnumerable<ImportRecordForDisplayDto>>(importRecords).ToList();
                IEnumerable<Product> products = await Repository.Product.GetByConditionAsync(p => productIds.Any(id => id.Equals(p.ID)), parameters);
                var productList = products.ToList();
                result.ForEach(r =>
                {
                    var p = productList.Single(p => p.ID.Equals(r.ProductID));
                    r.ProductName = p.Name;
                });
                return Ok(new
                {
                    body = result,
                    pages = this.GetPagination(importRecords)
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddImportRecord([FromBody] ImportRecordForCreationDto importRecordForCreationDto)
        {
            ImportRecord importRecord = Mapper.Map<ImportRecord>(importRecordForCreationDto);
            importRecord.ID = Guid.NewGuid();
            Repository.ImportRecord.Create(importRecord);
            if (!await Repository.ImportRecord.SaveAsync())
                return BadRequest();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateImportRecord([FromBody] ImportRecordForUpdateDto importRecordForUpdateDto)
        {
            ImportRecord importRecord = Mapper.Map<ImportRecord>(importRecordForUpdateDto);
            ImportRecord oldRecord = await Repository.ImportRecord.GetByIdAsync(importRecordForUpdateDto.ID);
            if (oldRecord != null)
            {
                oldRecord.Quantity = importRecord.Quantity;
                oldRecord.ImportPrice = importRecord.ImportPrice;
                oldRecord.Status = importRecord.Status;
                oldRecord.UpdateTime = DateTime.Now;
                Repository.ImportRecord.Update(oldRecord);
                if (oldRecord.Status.Equals(2))
                {
                    Product product = await Repository.Product.GetByIdAsync(oldRecord.ProductID);
                    product.Quantity += oldRecord.Quantity;
                    Repository.Product.Update(product);
                    if (!await Repository.Product.SaveAsync())
                        return BadRequest();
                }
                else
                {
                    if (!await Repository.ImportRecord.SaveAsync())
                        return BadRequest();
                }
            }
            return NoContent();
        }
    }
}