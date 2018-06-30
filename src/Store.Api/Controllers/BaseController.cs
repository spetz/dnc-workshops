using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
    }
}