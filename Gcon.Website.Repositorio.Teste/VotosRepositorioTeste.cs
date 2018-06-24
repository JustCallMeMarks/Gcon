using System;
using Gcon.Website.Dominio.Entidade.Votos;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class VotosRepositorioTeste
    {
        [TestMethod]
        public void GravarVotos()
        {
            Votos Votos = new Votos()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PERGUNTA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                RESPOSTA ="Teste Resposta"

            };
            try
            {
                VotosRepositorio votosRepositorio = new VotosRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
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
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PERGUNTA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                RESPOSTA = "Teste Resposta - Altera"

            };
            try
            {
                VotosRepositorio votosRepositorio = new VotosRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
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
                VotosRepositorio votosRepositorio = new VotosRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
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
                VotosRepositorio votosRepositorio = new VotosRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
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
