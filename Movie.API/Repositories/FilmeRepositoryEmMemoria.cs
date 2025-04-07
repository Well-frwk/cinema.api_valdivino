using Shared.DTOs;
using Shared.Interfaces;

namespace Movie.API.Repositories
{
    public class FilmeRepositoryEmMemoria : IFilmeRepository
    {
        private static readonly List<FilmeDto> _filmes = new()
    {
        new FilmeDto
        {
            Id = Guid.NewGuid(),
            Nome = "Clube da Luta",
            Descricao = "Um homem insatisfeito com sua vida conhece Tyler Durden e funda um clube de luta secreto.",
            DataLancamento = new DateTimeOffset(new DateTime(1999, 10, 15))
        },
        new FilmeDto
        {
            Id = Guid.NewGuid(),
            Nome = "Matrix",
            Descricao = "Um hacker descobre que a realidade é uma simulação criada por máquinas.",
            DataLancamento = new DateTimeOffset(new DateTime(1999, 3, 31))
        }
    };

        public Task<IEnumerable<FilmeDto>> ObterTodosAsync()
            => Task.FromResult<IEnumerable<FilmeDto>>(_filmes);

        public Task<FilmeDto?> ObterPorIdAsync(Guid id)
            => Task.FromResult(_filmes.FirstOrDefault(f => f.Id == id));

        public Task AdicionarAsync(FilmeDto filme)
        {
            filme.Id = Guid.NewGuid();
            _filmes.Add(filme);
            return Task.CompletedTask;
        }

        public Task AtualizarAsync(FilmeDto filme)
        {
            var index = _filmes.FindIndex(f => f.Id == filme.Id);
            if (index >= 0)
                _filmes[index] = filme;

            return Task.CompletedTask;
        }

        public Task RemoverAsync(Guid id)
        {
            var filme = _filmes.FirstOrDefault(f => f.Id == id);
            if (filme is not null)
                _filmes.Remove(filme);

            return Task.CompletedTask;
        }
    }
}
