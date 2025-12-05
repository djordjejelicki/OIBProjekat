using Microsoft.AspNetCore.Mvc;

namespace PetShop.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
