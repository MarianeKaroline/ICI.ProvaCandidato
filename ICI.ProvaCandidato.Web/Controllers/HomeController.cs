using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<NoticiaController> _logger;

        public HomeController(ILogger<NoticiaController> logger)
        {
            _logger= logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
