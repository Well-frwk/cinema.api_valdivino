using Shared.DTOs;

namespace Shared.Interfaces
{
    public interface IBilheteRepository
    {
        Task<IEnumerable<BilheteDto>> ObterPorUsuarioAsync(Guid usuarioId);
        Task<BilheteDto?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(BilheteDto bilhete);
        Task AtualizarAsync(BilheteDto bilhete);
        Task RemoverAsync(Guid id);
    }
}
