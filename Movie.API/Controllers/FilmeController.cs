using Microsoft.AspNetCore.Mvc;
using Movie.API.Services;
using Shared.DTOs;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filmes = await _filmeService.ObterTodosAsync();
            return Ok(filmes);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var filme = await _filmeService.ObterPorIdAsync(id);
            return filme is not null ? Ok(filme) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilmeDto filme)
        {
            await _filmeService.AdicionarAsync(filme);
            return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] FilmeDto filme)
        {
            if (id != filme.Id)
                return BadRequest("ID do filme não confere.");

            await _filmeService.AtualizarAsync(filme);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _filmeService.RemoverAsync(id);
            return NoContent();
        }
    }
}
