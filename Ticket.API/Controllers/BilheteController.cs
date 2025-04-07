using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Ticket.API.Services;

namespace Ticket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BilheteController : ControllerBase
    {
        private readonly BilheteService _service;

        public BilheteController(BilheteService service)
        {
            _service = service;
        }

        [HttpGet("usuario/{usuarioId:guid}")]
        public async Task<IActionResult> GetByUsuario(Guid usuarioId)
        {
            var bilhetes = await _service.ObterPorUsuarioAsync(usuarioId);
            return Ok(bilhetes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bilhete = await _service.ObterPorIdAsync(id);
            return bilhete is not null ? Ok(bilhete) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BilheteDto bilhete)
        {
            await _service.AdicionarAsync(bilhete);
            return CreatedAtAction(nameof(Get), new { id = bilhete.Id }, bilhete);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BilheteDto bilhete)
        {
            if (id != bilhete.Id)
                return BadRequest("ID do bilhete não confere.");

            await _service.AtualizarAsync(bilhete);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
