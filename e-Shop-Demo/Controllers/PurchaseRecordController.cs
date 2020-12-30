using AutoMapper;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

        //[HttpGet]
        //public async Task<ActionResult> GetPurchaseDetailRecords([FromQuery] PurchaseDetailRecordResourceParameters parameters)
        //{
        //    IEnumerable<PurchaseDetailRecord> purchaseDetailRecords = await Repository.PurchaseDetailRecord.GetAllAsync(parameters);
        //    if (purchaseDetailRecords == null)
        //        return BadRequest("No Customer");
        //    else
        //    {
        //        var result = Mapper.Map<IEnumerable<PurchaseDetailRecord>>(purchaseDetailRecords);
        //        return Ok(new
        //        {
        //            body = result,
        //            pages = this.GetPagination(purchaseDetailRecords)
        //        });
        //    }
        //}
    }
}