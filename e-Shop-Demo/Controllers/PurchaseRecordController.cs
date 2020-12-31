using AutoMapper;
using e_Shop_Demo.Dtos.PurchaseRecord;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PurchaseRecordController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public ILogger<PurchaseRecordController> Logger { get; }
        public PurchaseRecordController(IRepositoryWrapper wrapper, IMapper mapper, IConfiguration configuration,
                                  ILogger<PurchaseRecordController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            Logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseRecords([FromQuery] PurchaseRecordResourceParameters parameters)
        {
            IEnumerable<PurchaseRecord> purchaseRecords = await Repository.PurchaseRecord.GetAllRecordsAsync(parameters);
            if (purchaseRecords.Count().Equals(0))
                return BadRequest("No PurchaseRecord");
            else
            {
                var mappedpurchaseRecords = Mapper.Map<IEnumerable<PurchaseRecordForDisplayDto>>(purchaseRecords);
                var result = mappedpurchaseRecords.ToList();
                result.ForEach(p =>
                {
                    p.DisplayList = Mapper.Map<IEnumerable<PurchaseDetailRecordForDisplayDto>>(p.PurchaseDetailRecords);
                    p.PurchaseDetailRecords = null;
                });
                return Ok(new
                {
                    body = result,
                    pages = this.GetPagination(purchaseRecords)
                });
            }
        }
    }
}