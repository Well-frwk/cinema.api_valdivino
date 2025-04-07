using Shared.DTOs;
using Shared.Interfaces;

namespace Ticket.API.Repositories
{
    public class BilheteRepositoryEmMemoria : IBilheteRepository
    {
        private static readonly List<BilheteDto> _bilhetes = new();

        public Task<IEnumerable<BilheteDto>> ObterPorUsuarioAsync(Guid usuarioId)
            => Task.FromResult(_bilhetes.Where(b => b.UsuarioId == usuarioId).AsEnumerable());

        public Task<BilheteDto?> ObterPorIdAsync(Guid id)
            => Task.FromResult(_bilhetes.FirstOrDefault(b => b.Id == id));

        public Task AdicionarAsync(BilheteDto bilhete)
        {
            bilhete.Id = Guid.NewGuid();
            bilhete.DataCompra = DateTime.Now;
            _bilhetes.Add(bilhete);
            return Task.CompletedTask;
        }

        public Task AtualizarAsync(BilheteDto bilhete)
        {
            var index = _bilhetes.FindIndex(b => b.Id == bilhete.Id);
            if (index >= 0)
                _bilhetes[index] = bilhete;

            return Task.CompletedTask;
        }

        public Task RemoverAsync(Guid id)
        {
            var bilhete = _bilhetes.FirstOrDefault(b => b.Id == id);
            if (bilhete is not null)
                _bilhetes.Remove(bilhete);

            return Task.CompletedTask;
        }
    }
}
