using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Data.Dtos;
using Usuarios.Api.Services;

namespace Usuarios.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastrarAsync(dto);
            return Ok("Usuario cadastrado!");
        }
         
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginAsync(dto);
            return Ok(token);
        }
    }
}