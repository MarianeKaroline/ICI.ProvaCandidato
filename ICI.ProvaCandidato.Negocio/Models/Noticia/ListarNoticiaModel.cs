using ICI.ProvaCandidato.Negocio.Models.Tag;
using System.Collections.Generic;

namespace ICI.ProvaCandidato.Negocio.Models.Noticia
{
    public class ListarNoticiaModel
    {
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public List<ListarTagModel> Tags { get; set; }
    }
}
