using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Models.Noticia
{
    public class SalvarNoticiaModel
    {
        public int? Id { get; set; }
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Titulo obrigatório")]
        [MaxLength(250)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Texto obrigatório")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "Tag obrigatória")]
        [MinLength(1, ErrorMessage = "Precisa selecionar ao menos uma tag")]
        public List<int> TagsIds { get; set; }
    }
}
