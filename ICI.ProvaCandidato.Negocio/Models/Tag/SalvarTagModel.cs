using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Models.Tag
{
    public class SalvarTagModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Descricao obrigatório")]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
