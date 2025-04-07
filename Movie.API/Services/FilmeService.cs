using Shared.DTOs;
using Shared.Interfaces;

namespace Movie.API.Services
{
    public class FilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public Task<IEnumerable<FilmeDto>> ObterTodosAsync() =>
            _filmeRepository.ObterTodosAsync();

        public Task<FilmeDto?> ObterPorIdAsync(Guid id) =>
            _filmeRepository.ObterPorIdAsync(id);

        public Task AdicionarAsync(FilmeDto filme) =>
            _filmeRepository.AdicionarAsync(filme);

        public Task AtualizarAsync(FilmeDto filme) =>
            _filmeRepository.AtualizarAsync(filme);

        public Task RemoverAsync(Guid id) =>
            _filmeRepository.RemoverAsync(id);
    }
}
