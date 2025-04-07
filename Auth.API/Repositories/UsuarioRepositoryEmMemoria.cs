using Shared.DTOs;
using Shared.Interfaces;

namespace Auth.API.Repositories
{
    public class UsuarioRepositoryEmMemoria : IUsuarioRepository
    {
        private static readonly List<UsuarioDto> _usuarios = new();

        public Task<UsuarioDto?> ObterPorEmailAsync(string email)
            => Task.FromResult(_usuarios.FirstOrDefault(u => u.Email == email));

        public Task<UsuarioDto> CriarAsync(UsuarioDto usuario)
        {
            usuario.Id = Guid.NewGuid();
            _usuarios.Add(usuario);
            return Task.FromResult(usuario);
        }
    }
}
