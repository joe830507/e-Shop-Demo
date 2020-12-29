using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Entities;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IDistributedCache DistributedCache { get; }
        public IMapper Mapper { get; }
        public ILogger<ProductTypeController> Logger { get; }
        public ProductTypeController(IRepositoryWrapper wrapper, IMapper mapper, IDistributedCache distributedCache,
            IConfiguration configuration, ILogger<ProductTypeController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            DistributedCache = distributedCache;
            Configuration = configuration;
            Logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddProductType([FromBody] ProductTypeForCreationDto productTypeForCreationDto)
        {
            bool isExist = await Repository.ProductType.IsExistAsync(productTypeForCreationDto.Name);
            if (isExist)
            {
                return BadRequest("This productType has existed.");
            }
            ProductType productType = Mapper.Map<ProductType>(productTypeForCreationDto);
            productType.ID = Guid.NewGuid();
            productType.Order = await Repository.ProductType.GetMaxOrder() + 1;
            Repository.ProductType.Create(productType);
            if (!await Repository.ProductType.SaveAsync())
                return BadRequest();
            return NoContent();
        }
    }
}