using Shared.DTOs;

namespace Shared.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDto?> ObterPorEmailAsync(string email);
        Task<UsuarioDto> CriarAsync(UsuarioDto usuario);
    }
}
