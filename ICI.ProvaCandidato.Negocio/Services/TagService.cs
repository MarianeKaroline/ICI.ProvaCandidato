using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class TagService
    {
        private readonly UnitOfWork _unitOfWork;

        public TagService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ListarTagModel ObterPorId(int id)
        {
            return _unitOfWork.TagRepository
                .Where(w => w.Id == id)
                .Select(s => new ListarTagModel()
                {
                    Descricao = s.Descricao,
                    TagId = s.Id
                })
                .FirstOrDefault();
        }

        public List<ListarTagModel> Listar() 
        { 
            return _unitOfWork.TagRepository
                .AsQueryable()
                .Select(t => new ListarTagModel()
                {
                    TagId = t.Id,
                    Descricao = t.Descricao
                })
                .ToList();
        }

        public int Salvar(SalvarTagModel salvarTag)
        {
            Tag tag;

            if (salvarTag.Id.HasValue)
            {
                tag = _unitOfWork.TagRepository
                    .GetById(salvarTag.Id.Value);

                tag.Descricao = salvarTag.Descricao;

                _unitOfWork.TagRepository.Update(tag);
            }
            else
            {
                tag = new Tag()
                {
                    Descricao = salvarTag.Descricao
                };

                _unitOfWork.TagRepository.Add(tag);
            }
            _unitOfWork.Commit();

            return tag.Id;
        }

        public void Excluir(int id)
        {
            var vinculo = _unitOfWork.TagRepository
                .Any(a => a.NoticiaTags != null && a.NoticiaTags.Any(a => a.TagId == id));

            if (vinculo)
                throw new Exception("Tag está vinculada a uma notícia");

            _unitOfWork.TagRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
