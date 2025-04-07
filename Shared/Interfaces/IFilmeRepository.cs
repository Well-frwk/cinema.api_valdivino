using Shared.DTOs;

namespace Shared.Interfaces
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<FilmeDto>> ObterTodosAsync();
        Task<FilmeDto?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(FilmeDto filme);
        Task AtualizarAsync(FilmeDto filme);
        Task RemoverAsync(Guid id);
    }
}
