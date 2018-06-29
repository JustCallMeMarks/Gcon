using System;
using Gcon.Website.Dominio.Entidade.Reunioes;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Collections.Generic;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class ReunioesRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarReunioes()
        {
            Reunioes Reunioes = new Reunioes()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2018"),
                titulo = "Teste Titulo",
                data_atz = DateTime.Parse("01/01/2058")
            };
            try
            {
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
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
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2098"),
                titulo = "Teste Titulo = Altera",
                data_atz = DateTime.Parse("01/01/2158")
            };
            try
            {
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
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
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
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
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
                Reunioes Reunioes = reunioesRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTodasReunioesDeUmCondominio()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
                List<Reunioes> Reunioes = reunioesRepositorio.ProcurarTodasReunioesDeUmCondominio(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
