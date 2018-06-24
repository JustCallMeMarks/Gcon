using System;
using Gcon.Website.Dominio.Entidade.Reunioes;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class ReunioesRepositorioTeste
    {
        [TestMethod]
        public void GravarReunioes()
        {
            Reunioes Reunioes = new Reunioes()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("01/01/2018"),
                TITULO = "Teste Titulo",
                DATA_ATZ = DateTime.Parse("01/01/2058")
            };
            try
            {
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                reunioesRepositorio.Inserir(Reunioes);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarReunioes()
        {
            Reunioes Reunioes = new Reunioes()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("01/01/2098"),
                TITULO = "Teste Titulo = Altera",
                DATA_ATZ = DateTime.Parse("01/01/2158")
            };
            try
            {
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                reunioesRepositorio.Alterar(Reunioes);
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
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                reunioesRepositorio.Excluir(Id);
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
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                Reunioes Reunioes = reunioesRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
