using Microsoft.AspNetCore.Mvc;

namespace Store.Services.Products.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
            => Content("Store Products Service.");
    }
}