using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KentuckyProudSeedCo.Service.Controllers
{
    //[Authorize]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        
    }
}
