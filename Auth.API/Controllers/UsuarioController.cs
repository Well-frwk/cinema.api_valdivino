using Auth.API.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDto usuario)
        {
            var existente = await _service.ObterPorEmailAsync(usuario.Email);
            if (existente is not null)
                return Conflict("E-mail já cadastrado.");

            var criado = await _service.CriarAsync(usuario);
            return CreatedAtAction(nameof(Register), new { id = criado.Id }, criado);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDto login)
        {
            var usuario = await _service.ObterPorEmailAsync(login.Email);
            if (usuario is null || usuario.Senha != login.Senha)
                return Unauthorized("Credenciais inválidas.");

            return Ok(new
            {
                Token = Guid.NewGuid(), // token fake
                Usuario = new { usuario.Id, usuario.Nome, usuario.Email }
            });
        }
    }
}
