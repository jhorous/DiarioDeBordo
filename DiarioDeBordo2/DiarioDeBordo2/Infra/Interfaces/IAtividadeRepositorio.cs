using Biblioteca.Enums;
using Dominio.Entidades;
using System.Collections.Generic;

namespace Infra.Interfaces
{
    public interface IAtividadeRepositorio
    {
        IEnumerable<Atividade> Listar(int codigo);
        Atividade Inserir(Atividade request);
        Atividade Alterar(Atividade request);
        int Excluir(int codigo);
    }
}
