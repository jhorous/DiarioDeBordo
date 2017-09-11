using Dapper;
using Infra.Interfaces;
using System.Linq;
using System.Text;
using Biblioteca.Classes;
using System.Collections.Generic;
using Dominio.Entidades;

namespace Infra
{
    public class AtividadeRepositorio: IAtividadeRepositorio
  {
  public IEnumerable<Atividade> Listar(int codigo)
    {
        using (var conexao = BancoDeDados.Conexao())
        {
            conexao.Open();

            StringBuilder query = new StringBuilder(@"Select A.CODATIVIDADE AS CodigoAtividade,
  A.CODATIVIDADEPRINCIPAL AS CodigoAtividadePrincipal,
  A.IDTTIPOATIVIDADE AS TipoAtividade,
  A.DESCRICAOATIVIDADE AS DescAtividade
  FROM ATIVIDADE A
  WHERE 1 = 1 ");

            DynamicParameters parametros = new DynamicParameters();

            if (codigo > 0)
            {
                parametros.Add("CODIGO", codigo);
                query.Append(" And A.CODATIVIDADE = @Codigo");
            }

      query.Append(" Order By A.DESCRICAOATIVIDADE");

            return conexao.Query<Atividade>(query.ToString(), parametros).ToList();
        }
    }

    public Atividade Inserir(Atividade request)
    {
        using (var conexao = BancoDeDados.Conexao())
        {
            conexao.Open();

            StringBuilder query = new StringBuilder(@"INSERT INTO ATIVIDADE
  (CODATIVIDADEPRINCIPAL,
  IDTTIPOATIVIDADE,
  DESCRICAOATIVIDADE)
  ValuesDescricao
  (@CodigoAtividadePrincipal,
  @TipoAtividade,
  @DescAtividade);

  Select Cast(SCOPE_IDENTITY() as int) ");

            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("CodigoAtividadePrincipal", request.CodAtividadePrincipal);
            parametros.Add("TipoAtividade", request.TipoAtividade);
            parametros.Add("DescAtividade", request.DescAtividade);

            int codigoAtividade = conexao.Query<int>(query.ToString(), parametros).Single();

            var atividade = new Atividade(codigoAtividade,
            request.CodAtividadePrincipal,
            request.TipoAtividade,
            request.DescAtividade);

            return atividade;
        }
    }

    public Atividade Alterar(Atividade request)
    {
        using (var conexao = BancoDeDados.Conexao())
        {
            conexao.Open();

            StringBuilder query = new StringBuilder(@"UPDATE ATIVIDADE
  SET CODATIVIDADEPRINCIPAL = @CodigoAtividadePrincipal,
  IDTTIPOATIVIDADE = @TipoAtividade,
  DESCRICAOATIVIDADE = @DescAtividade
  WHERE CODATIVIDADE = @Codigo ");

            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("CodigoAtividadePrincipal", request.CodAtividadePrincipal);
            parametros.Add("TipoAtividade", request.TipoAtividade);
            parametros.Add("DescAtividade", request.DescAtividade);
           

            conexao.Execute(query.ToString(), parametros);

            var atividade = new Atividade(request.CodAtividade,
            request.CodAtividadePrincipal,
            request.TipoAtividade,
            request.DescAtividade);

            return atividade;
        }

    }

    public int Excluir(int codigo)
    {
        using (var conexao = BancoDeDados.Conexao())
        {
            conexao.Open();

            StringBuilder query = new StringBuilder(@"DELETE 
  FROM ATIVIDADE
  WHERE CODATIVIDADE = @Codigo ");

            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("Codigo", codigo);

            conexao.Execute(query.ToString(), parametros);

            return codigo;
        }
    }
}
}