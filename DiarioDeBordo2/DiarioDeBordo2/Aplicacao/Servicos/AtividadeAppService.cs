using Aplicacao.Interfaces;
using AutoMapper;
using Biblioteca.Excecoes;
using Biblioteca.Interfaces;
using DataTransfer.Requests;
using DataTransfer.Responses;
using Dominio.Entidades;
using Infra.Interfaces;
using System.Collections.Generic;

namespace Aplicacao.Servicos
{
    public class AtividadeAppService : IAppServiceBase, IAtividadeAppService
    {
        private readonly IAtividadeRepositorio atividadeRepositorio;
        private MapperConfiguration configuracoesDeMapeamento;

        public AtividadeAppService(IAtividadeRepositorio atividadeRepositorio)
        {
            this.atividadeRepositorio = atividadeRepositorio;

            this.ConfigurarMapeamento();
        }

        public void ConfigurarMapeamento()
        {
            this.configuracoesDeMapeamento = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Atividade, AtividadeResponse>();
                cfg.CreateMap<AtividadeRequest, Atividade>();
            });

            this.configuracoesDeMapeamento.AssertConfigurationIsValid();
        }

        public IEnumerable<AtividadeResponse> Listar(int codigo)
        {
            if (codigo <= 0)
            {
                throw new ParametroInvalidoExcecao("Favor informar um código de atividade válido");
            }

            var lista = this.atividadeRepositorio.Listar(codigo);

            return this.configuracoesDeMapeamento.CreateMapper().Map<IEnumerable<Atividade>, IEnumerable<AtividadeResponse>>(lista);
        }

        public IEnumerable<AtividadeResponse> Listar()
        {
            var lista = this.atividadeRepositorio.Listar(0);

            return this.configuracoesDeMapeamento.CreateMapper().Map<IEnumerable<Atividade>, IEnumerable<AtividadeResponse>>(lista);
        }

        public AtividadeResponse Inserir(AtividadeRequest request)
        {
            if ((request == null))
            {
                throw new ParametroInvalidoExcecao("Deve informar os parâmetros para inserir o perfil.");
            }

            var lista = this.atividadeRepositorio.Inserir(this.configuracoesDeMapeamento.CreateMapper().
            Map<AtividadeRequest, Atividade>(request));

            return this.configuracoesDeMapeamento.CreateMapper().Map<Atividade, AtividadeResponse>(lista);
        }

        public AtividadeResponse Alterar(AtividadeRequest request)
        {
            if ((request == null))
            {
                throw new ParametroInvalidoExcecao("Deve informar os parâmetros para alterar o perfil.");
            }

            var lista = this.atividadeRepositorio.Alterar(this.configuracoesDeMapeamento.CreateMapper().
            Map<AtividadeRequest, Atividade>(request));

            return this.configuracoesDeMapeamento.CreateMapper().Map<Atividade, AtividadeResponse>(lista);
        }

        public int Excluir(int codigo)
        {
            if (codigo <= 0)
            {
                throw new ParametroInvalidoExcecao("Favor informar um código de atividade válido");
            }

            return this.atividadeRepositorio.Excluir(codigo);
        }
    }
}
