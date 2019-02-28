using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain BuscarPorEmailSenha(string Email, string Senha);
    }
}
