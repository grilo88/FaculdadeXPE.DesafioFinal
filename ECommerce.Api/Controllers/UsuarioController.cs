using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
