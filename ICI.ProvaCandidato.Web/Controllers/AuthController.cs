using ICI.ProvaCandidato.Negocio.Models.Auth;
using ICI.ProvaCandidato.Negocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService, CookieOptions cookieOptions) : base(cookieOptions)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            LoginAuthModel loginAuthModel= new();
            return View(loginAuthModel);
        }

        public IActionResult Registrar()
        {
            var cookie = Request.Cookies["usuario"];

            if (cookie != null)
                return RedirectToAction("Index", "Home");

            RegistrarAuthModel registrarModel = new();
            return View(registrarModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginAuthModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _authService.Login(loginModel);

                    Response.Cookies.Append("usuario", id.ToString(), _cookieOptions);
                    TempData["usuarioLogado"] = id;
                    TempData.Keep("usuarioLogado");

                    return RedirectToAction("Index", "Home");
                }

                return View(loginModel);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;

                return View(loginModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarAuthModel registrarModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _authService.Cadastrar(registrarModel);
                    return RedirectToAction("Index");
                }

                return View(registrarModel);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Registrar");
            }
        }

        public IActionResult Sair()
        {
            Response.Cookies.Delete("usuario");
            TempData.Clear();

            return RedirectToAction("index");
        }
    }
}
