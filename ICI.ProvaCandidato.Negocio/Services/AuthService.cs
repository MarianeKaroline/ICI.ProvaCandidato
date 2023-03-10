using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Dados.Entities;
using ICI.ProvaCandidato.Negocio.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Services
{
    public class AuthService
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Login(LoginAuthModel loginModel)
        {
            var usuario = await _unitOfWork.UsuarioRepository
                .Where(w => w.Email == loginModel.Email)
                .FirstOrDefaultAsync();

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            if (loginModel.Senha != usuario.Senha)
                throw new Exception("Senha incorreta.");

            return usuario.Id;
        }

        public async Task<int> Cadastrar(RegistrarAuthModel registrarModel)
        {
            var usuario = await _unitOfWork.UsuarioRepository
                .Where(w => w.Email == registrarModel.Email)
                .FirstOrDefaultAsync();

            if (usuario != null)
                throw new Exception("Já existe um usuário com este e-mail");

            usuario = new Usuario()
            {
                Email = registrarModel.Email,
                Nome = registrarModel.Nome,
                Senha = registrarModel.Senha
            };

            _unitOfWork.UsuarioRepository.Add(usuario);
            _unitOfWork.Commit();

            return usuario.Id;
        }
    }
}
