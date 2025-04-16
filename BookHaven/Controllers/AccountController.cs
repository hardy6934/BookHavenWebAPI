using Microsoft.AspNetCore.Mvc;

namespace BookHaven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    { 

        public IActionResult Index()
        {
            return View();
        }
    }
}
