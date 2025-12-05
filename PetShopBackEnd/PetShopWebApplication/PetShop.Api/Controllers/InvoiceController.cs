using Microsoft.AspNetCore.Mvc;

namespace PetShop.Api.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
