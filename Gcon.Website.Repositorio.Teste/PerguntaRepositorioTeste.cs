using System;
using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class PerguntaRepositorioTeste
    {
        [TestMethod]
        public void GravarPergunta()
        {
            Pergunta Pergunta = new Pergunta()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_VOTACAO = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                PERGUNTA = "Pergunta teste",
                TIPO = "Teste Tipo"
            };
            try
            {
                PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                perguntaRepositorio.Inserir(Pergunta);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarPergunta()
        {
            Pergunta Pergunta = new Pergunta()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_VOTACAO = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                PERGUNTA = "Pergunta teste - Altera",
                TIPO = "Teste Tipo - Altera"
            };
            try
            {
                PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                perguntaRepositorio.Alterar(Pergunta);
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
                PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                perguntaRepositorio.Excluir(Id);
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
                PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                Pergunta Pergunta = perguntaRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
