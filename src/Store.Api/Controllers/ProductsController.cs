using System;
using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
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
        public ActionResult Post()
        {
            return Ok();
        }
    }
}