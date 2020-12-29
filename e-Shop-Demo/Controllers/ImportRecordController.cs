using AutoMapper;
using e_Shop_Demo.Dtos.ImportRecord;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

        [HttpPost]
        public async Task<ActionResult> AddImportRecord([FromBody] ImportRecordForCreationDto importRecordForCreationDto)
        {
            return null;
        }
    }
}