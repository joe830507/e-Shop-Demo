﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using e_Shop_Demo.Dtos;
using e_Shop_Demo.Dtos.Product;
using e_Shop_Demo.Entities;
using e_Shop_Demo.Extensions;
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
            var productTypes = await Repository.ProductType.GetAllAsync(null);
            var result = Mapper.Map<IEnumerable<ProductForDisplayDto>>(pagedList);
            result.ToList().ForEach(p =>
            {
                var name = productTypes.Where(pt => pt.ID.ToString().Equals(p.Type)).Single().Name;
                p.Type = name;
            });
            return Ok(new
            {
                body = result,
                productTypes,
                pages = this.GetPagination(pagedList)
            });
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

        [HttpPost(Name = nameof(AddProduct))]
        public async Task<ActionResult> AddProduct([FromBody] ProductForCreationDto productForCreationDto)
        {
            Product product = Mapper.Map<Product>(productForCreationDto);
            product.ID = Guid.NewGuid();
            product.CreateTime = DateTime.Now;
            Repository.Product.Create(product);
            if (!await Repository.Product.SaveAsync())
                return BadRequest();
            return NoContent();
        }

        [HttpPut(Name = nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductForUpdateDto productForUpdateDto)
        {
            Product product = Mapper.Map<Product>(productForUpdateDto);
            if (!await Repository.Product.IsExistAsync(product.ID))
                return NotFound();
            product.UpdateTime = DateTime.Now;
            Repository.Product.Update(product);
            if (!await Repository.Product.SaveAsync())
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProducts([FromBody] ProductForDeleteDto productForDeleteDto)
        {
            Repository.Product.DeleteProducts(productForDeleteDto.Products);
            if (!await Repository.Product.SaveAsync())
                return BadRequest("Some error happens");
            return NoContent();
        }
    }
}