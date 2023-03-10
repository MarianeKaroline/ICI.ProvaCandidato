using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Models.Auth
{
    public class RegistrarAuthModel
    {
        [Required(ErrorMessage = "Nome obrigatório")]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [MaxLength(250)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        [MaxLength(250)]
        public string Email { get; set; }
    }
}
