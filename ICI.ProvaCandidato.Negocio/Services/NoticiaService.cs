using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Models.Noticia;
using ICI.ProvaCandidato.Negocio.Models.Tag;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class NoticiaService
    {
        private readonly UnitOfWork _unitOfWork;

        public NoticiaService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ListarNoticiaModel BuscarPorId(int id)
        {
            return _unitOfWork.NoticiaRepository
                .Where(w => w.Id == id)
                .Select(s => new ListarNoticiaModel()
                {
                    NomeUsuario = s.Usuario.Nome,
                    NoticiaId = id,
                    Tags = s.NoticiaTags.Select(p => new ListarTagModel()
                    {
                        Descricao = p.Tag.Descricao,
                        TagId = p.Tag.Id
                    })
                    .ToList(),
                    UsuarioId = s.UsuarioId,
                    Texto = s.Texto,
                    Titulo = s.Titulo,
                })
                .FirstOrDefault();
        }

        public List<ListarNoticiaModel> Listar()
        {
            return _unitOfWork.NoticiaRepository
                .AsQueryable()
                .Select(s => new ListarNoticiaModel()
                {
                    NoticiaId = s.Id,
                    Titulo = s.Titulo,
                    Texto = s.Texto,
                    Tags = s.NoticiaTags.Select(p => new ListarTagModel()
                    {
                        Descricao = p.Tag.Descricao,
                        TagId = p.Tag.Id
                    })
                    .ToList(),
                    UsuarioId = s.UsuarioId,
                    NomeUsuario = s.Usuario.Nome
                })
                .ToList();
        }

        public int Salvar(SalvarNoticiaModel salvarNoticia)
        {
            Noticia noticia = new();

            if (salvarNoticia.Id.HasValue)
            {
                noticia = _unitOfWork.NoticiaRepository
                    .Where(w => w.Id == salvarNoticia.Id.Value)
                    .Include(i => i.NoticiaTags)
                    .FirstOrDefault();

                noticia.Titulo = salvarNoticia.Titulo;
                noticia.Texto = salvarNoticia.Texto;
                noticia.UsuarioId = salvarNoticia.UsuarioId;

                foreach (var tag in noticia.NoticiaTags)
                    _unitOfWork.NoticiaTagRepository.Delete(tag.Id);                

                noticia.NoticiaTags = salvarNoticia.TagsIds
                    .Select(s => new NoticiaTag()
                    {
                        TagId = s
                    })
                    .ToList();

                _unitOfWork.NoticiaRepository.Update(noticia);
            }
            else
            {
                noticia = new Noticia()
                {
                    Titulo = salvarNoticia.Titulo,
                    Texto = salvarNoticia.Texto,
                    UsuarioId = salvarNoticia.UsuarioId,
                    NoticiaTags = salvarNoticia.TagsIds.Select(s => new NoticiaTag()
                    {
                        TagId = s
                    })
                    .ToList()
                };

                _unitOfWork.NoticiaRepository.Add(noticia);
            }
            _unitOfWork.Commit();

            return noticia.Id;
        }

        public void Excluir(int id)
        {
            _unitOfWork.NoticiaRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
