using System;
using Gcon.Website.Dominio.Entidade.Votos;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class VotosRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarVotos()
        {
            Votos Votos = new Votos()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pergunta = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                resposta ="Teste Resposta"

            };
            try
            {
                VotosRepositorio votosRepositorio = new VotosRepositorio(str);
                votosRepositorio.Inserir(Votos);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarVotos()
        {
            Votos Votos = new Votos()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pergunta = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                resposta = "Teste Resposta - Altera"

            };
            try
            {
                VotosRepositorio votosRepositorio = new VotosRepositorio(str);
                votosRepositorio.Alterar(Votos);
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
                VotosRepositorio votosRepositorio = new VotosRepositorio(str);
                votosRepositorio.Excluir(Id);
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
                VotosRepositorio votosRepositorio = new VotosRepositorio(str);
                Votos Votos = votosRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
