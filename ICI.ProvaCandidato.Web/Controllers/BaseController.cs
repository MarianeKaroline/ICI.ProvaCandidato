using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CookieOptions _cookieOptions;

        public BaseController(CookieOptions cookieOptions)
        {
            _cookieOptions = cookieOptions;
        }
    }
}
