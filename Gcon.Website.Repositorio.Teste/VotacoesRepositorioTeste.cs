using System;
using Gcon.Website.Dominio.Entidade.Votacoes;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Gcon.Website.Dominio.Entidade.Pergunta;
using System.Collections.Generic;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class VotacoesRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarVotacoes()
        {
            Votacoes Votacoes = new Votacoes()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2018"),
                titulo = "Teste Titulo",
                descricao = "Teste DESCRICAO"
            };
            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                votacoesRepositorio.Inserir(Votacoes);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarVotacoes()
        {
            Votacoes Votacoes = new Votacoes()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2058"),
                titulo = "Teste Titulo = altera",
                descricao = "Teste DESCRICAO = altera"
            };
            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                votacoesRepositorio.Alterar(Votacoes);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Exclui()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                votacoesRepositorio.Excluir(Id);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Procurar()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                Votacoes Votacoes = votacoesRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TodasPerguntasDeUmaVotação()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                List<Pergunta> Pergunta = votacoesRepositorio.TodasPerguntasDeUmaVotacao(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTodasVotacoesDeUmCondominio()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
                List<Votacoes> Votacoes = votacoesRepositorio.ProcurarTodasVotacoesDeUmCondominio(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
