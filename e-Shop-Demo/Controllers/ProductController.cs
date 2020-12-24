using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Helpers;
using e_Shop_Demo.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        public IRepositoryWrapper Repository { get; }
        public IConfiguration Configuration { get; }
        public IMapper Mapper { get; }
        public ILogger<ProductController> Logger { get; }

        public ProductController(IRepositoryWrapper wrapper, IMapper mapper, IConfiguration configuration,
                                  ILogger<ProductController> logger)
        {
            Repository = wrapper;
            Mapper = mapper;
            Logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] ResourceParameters parameters)
        {
            var pagedList = await Repository.Product.GetAllAsync(parameters);
            var paginationMetadata = new
            {
                totalCount = pagedList.TotalCount,
                pageSize = pagedList.PageSize,
                currentPage = pagedList.CurrentPage,
                totalPages = pagedList.TotalPages
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
            var result = Mapper.Map<IEnumerable<ProductDto>>(pagedList);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("types", Name = nameof(GetProductTypes))]
        [ResponseCache(Duration = 60 * 60 * 2, Location = ResponseCacheLocation.Client)]
        public async Task<ActionResult> GetProductTypes()
        {
            //var productTypes = await Repository.ProductType.GetAllAsync();
            //productTypes = productTypes.OrderBy(p => p.Order);
            //return Ok(productTypes);
            return null;
        }
    }
}