using Senai.InLock.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();
        void Cadastrar(JogoDomain jogo);
    }
}
