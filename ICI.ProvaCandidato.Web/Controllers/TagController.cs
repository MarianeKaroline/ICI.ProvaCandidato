using ICI.ProvaCandidato.Negocio.Models.Tag;
using ICI.ProvaCandidato.Negocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagController : BaseController
    {
        private readonly ILogger<NoticiaController> _logger;
        private readonly TagService _tagService;

        public TagController(ILogger<NoticiaController> logger, TagService tagService, CookieOptions cookieOptions) : base(cookieOptions)
        {
            _logger = logger;
            _tagService = tagService;
        }

        public IActionResult Index(string descricao)
        {
            var list = _tagService.Listar();

            if (!string.IsNullOrEmpty(descricao))
            {
                list = list
                    .Where(w => w.Descricao.ToLower().Contains(descricao.ToLower().Trim()))
                    .ToList();
            }

            ViewBag.Tags = list;

            return View();
        }

        public IActionResult Edicao(int? id)
        {
            var cookie = Request.Cookies["usuario"];

            if (cookie == null)
                return RedirectToAction("Index", "Home");

            SalvarTagModel model = new();
            if (id.HasValue)
            {
                var tag = _tagService.ObterPorId(id.Value);
                model.Descricao = tag.Descricao;
                model.Id = id.Value;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(SalvarTagModel salvarTag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tagService.Salvar(salvarTag);

                    return RedirectToAction("Index");
                }

                return View(salvarTag);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Registrar");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                _tagService.Excluir(id);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message; 
            }

            return RedirectToAction("Index");
        }
    }
}
