using AutoMapper;
using Usuarios.Api.Data.Dtos;
using Usuarios.Api.Models;

namespace Usuarios.Api.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
