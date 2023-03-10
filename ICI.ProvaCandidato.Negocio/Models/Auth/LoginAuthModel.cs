using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Negocio.Models.Auth
{
    public class LoginAuthModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [MaxLength(250)]
        public string Senha { get; set; }
    }
}
