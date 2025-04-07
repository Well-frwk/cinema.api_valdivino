using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class BilheteDto
    {
        public Guid Id { get; set; }
        public Guid FilmeId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
