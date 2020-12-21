using System;
using e_Shop_Demo.Enums;
using Microsoft.AspNetCore.Mvc;

namespace e_Shop_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetHomeInfo()
        {
            Array myArray = Enum.GetNames(typeof(ProductType));
            return Ok(myArray);
        }
    }
}