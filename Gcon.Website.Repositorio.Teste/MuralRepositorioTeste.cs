using System;
using Gcon.Website.Dominio.Entidade.Mural;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class MuralRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarMural()
        {
            Mural Mural = new Mural()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("01/01/2018"),
                TITULO = "Teste Titulo",
                TEXTO = "Teste Texto"
            };
            try
            {
                MuralRepositorio muralRepositorio = new MuralRepositorio(str);
                muralRepositorio.Inserir(Mural);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarMural()
        {
            Mural Mural = new Mural()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("31/12/2100"),
                TITULO = "Teste Titulo - Alterado",
                TEXTO = "Teste Texto - Alterado"
            };
            try
            {
                MuralRepositorio muralRepositorio = new MuralRepositorio(str);
                muralRepositorio.Alterar(Mural);
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
                MuralRepositorio muralRepositorio = new MuralRepositorio(str);
                muralRepositorio.Excluir(Id);
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
                MuralRepositorio muralRepositorio = new MuralRepositorio(str);
                Mural Mural = muralRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
