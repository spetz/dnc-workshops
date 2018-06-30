using System;
using Microsoft.AspNetCore.Mvc;
using Store.Messages.Products;

namespace Store.Api.Controllers
{
    //[ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public ActionResult Get() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id) 
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody]CreateProduct command)
        {
            return Ok();
        }
    }
}