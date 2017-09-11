using Biblioteca.Enums;
using System;

namespace Dominio.Entidades
{
    public class Atividade
    {
        public int CodAtividade { get; protected set; }
        public int CodAtividadePrincipal { get; protected set; }
        public NaoSimEnum TipoAtividade { get; protected set; }
        public string DescAtividade { get; protected set; }

        public Atividade()
        { }

        public Atividade(int codAtividade, int codAtividadePrincipal, NaoSimEnum tipoAtividade, String descAtividade)
        {
            CodAtividade = codAtividade;
            CodAtividadePrincipal = codAtividadePrincipal;
            TipoAtividade = NaoSimEnum.S;
            DescAtividade = _VerificaDescricao(descAtividade);
        }

        private string _VerificaDescricao(string descricao)
        {
            if (descricao.Length > 100)
            {
                throw new Exception("Tamanho da descrição não pode ser maior que 100 caracteres");
            }
            return descricao;


        }
    }


}
