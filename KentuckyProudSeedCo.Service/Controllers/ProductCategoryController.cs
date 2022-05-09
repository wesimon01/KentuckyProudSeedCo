using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KentuckyProudSeedCo.Service.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        //public Task<IActionResult> GetAllVegetables() 
        //{
            
            
        //}

        //public Task<I>

        
    }
}
