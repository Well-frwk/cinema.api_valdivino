using Shared.DTOs;
using Shared.Interfaces;

namespace Auth.API.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<UsuarioDto?> ObterPorEmailAsync(string email) =>
            _repository.ObterPorEmailAsync(email);

        public Task<UsuarioDto> CriarAsync(UsuarioDto usuario) =>
            _repository.CriarAsync(usuario);
    }
}
