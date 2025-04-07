using Shared.DTOs;
using Shared.Interfaces;

namespace Ticket.API.Services
{
    public class BilheteService
    {
        private readonly IBilheteRepository _repository;

        public BilheteService(IBilheteRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<BilheteDto>> ObterPorUsuarioAsync(Guid usuarioId) =>
            _repository.ObterPorUsuarioAsync(usuarioId);

        public Task<BilheteDto?> ObterPorIdAsync(Guid id) =>
            _repository.ObterPorIdAsync(id);

        public Task AdicionarAsync(BilheteDto bilhete) =>
            _repository.AdicionarAsync(bilhete);

        public Task AtualizarAsync(BilheteDto bilhete) =>
            _repository.AtualizarAsync(bilhete);

        public Task RemoverAsync(Guid id) =>
            _repository.RemoverAsync(id);
    }
}
