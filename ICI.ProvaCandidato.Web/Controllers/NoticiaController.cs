using ICI.ProvaCandidato.Negocio.Models.Noticia;
using ICI.ProvaCandidato.Negocio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Controllers
{
	public class NoticiaController : BaseController
	{
		private readonly ILogger<NoticiaController> _logger;
		private readonly NoticiaService _noticiaService;
		private readonly TagService _tagService;

        public NoticiaController(ILogger<NoticiaController> logger, NoticiaService noticiaService, TagService tagService, CookieOptions cookieOptions) : base(cookieOptions)
        {
			_logger = logger;
			_noticiaService = noticiaService;
			_tagService = tagService;
		}

		public IActionResult Index()
		{
			var list = _noticiaService.Listar();
			return View(list);
        }

        public IActionResult Edicao(int? id)
        {
            var cookie = Request.Cookies["usuario"];

            if (cookie == null)
                return RedirectToAction("Index", "Home");

			var usuarioId = int.Parse(cookie);
            var list = _tagService.Listar();

			ViewBag.TagsIds = new MultiSelectList(list, "TagId", "Descricao");

            SalvarNoticiaModel salvarNoticia = new SalvarNoticiaModel();
			if (id.HasValue)
			{
                var model = _noticiaService.BuscarPorId(id.Value);

				if (model.UsuarioId != usuarioId)
				{
                    TempData["ErroMessage"] = "Usuário não tem permissão para editar essa notícia";
                    return RedirectToAction("Index");
                }

				salvarNoticia.Id = id;
				salvarNoticia.Titulo = model.Titulo;
				salvarNoticia.Texto= model.Texto;
				salvarNoticia.TagsIds = model.Tags.Select(x => x.TagId).ToList();

                ViewBag.TagsIds = new MultiSelectList(list, "TagId", "Descricao", salvarNoticia.TagsIds);
            }

			salvarNoticia.UsuarioId = usuarioId;

            return View(salvarNoticia);
        }

        [HttpPost]
		public IActionResult Edicao(SalvarNoticiaModel salvarNoticia)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_noticiaService.Salvar(salvarNoticia);
					return RedirectToAction("Index");
                }

                var list = _tagService.Listar();

                ViewBag.TagsIds = new MultiSelectList(list, "TagId", "Descricao", salvarNoticia.TagsIds);
                return View(salvarNoticia);
			}
			catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Registrar");
            }
        }

		public IActionResult Excluir(int id, int usuId)
        {
            var cookie = Request.Cookies["usuario"];

            if (cookie == null)
                return RedirectToAction("Index", "Home");

            var usuarioId = int.Parse(cookie);

            if (usuId != usuarioId)
            {
                TempData["ErroMessage"] = "Usuário não tem permissão para excluir essa notícia";
                return RedirectToAction("Index");
            }

            _noticiaService.Excluir(id);

			return RedirectToAction("Index");
		}
	}
}
