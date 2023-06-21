using Microsoft.AspNetCore.Authorization;

namespace Usuarios.Api.Authorization
{
    public class IdadeMinima : IAuthorizationRequirement
    {
        public int Idade { get; set; }

        public IdadeMinima(int idade)
        {
            Idade = idade;
        }
    }
}