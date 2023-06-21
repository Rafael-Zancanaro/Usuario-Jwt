using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Usuarios.Api.Data.Dtos;
using Usuarios.Api.Models;

namespace Usuarios.Api.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task CadastrarAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
                throw new ApplicationException("Falha ao cadastrar usuario!"); 
        }

        public async Task<string> LoginAsync(LoginUsuarioDto dto)
        {
            SignInResult resultado = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, true);

            if (!resultado.Succeeded)
                throw new ApplicationException("Usuário ou senha inválido!");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName == dto.UserName.ToUpper());

            return _tokenService.GenerateToken(usuario);
        }
    }
}