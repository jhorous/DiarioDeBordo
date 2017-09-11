using Biblioteca.Enums;
using DataTransfer.Requests;
using DataTransfer.Responses;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{

  
    public interface IAtividadeAppService
    {
        IEnumerable<AtividadeResponse> Listar(int codigo);
        IEnumerable<AtividadeResponse> Listar();
        AtividadeResponse Inserir(AtividadeRequest request);
        AtividadeResponse Alterar(AtividadeRequest request);
        int Excluir(int codigo);
    }
}
