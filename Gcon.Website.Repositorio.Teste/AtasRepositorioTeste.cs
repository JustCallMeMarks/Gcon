using System;
using Gcon.Website.Dominio.Entidade.Atas;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gcon.Website.Repositorio.Teste;
using System.Configuration;
using System.Collections.Generic;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class AtasRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarAtas()
        {
            Atas Atas = new Atas()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2018"),
                titulo = "Teste Titulo",
                texto = "Teste Texto"
            };
            try
            {
                AtasRepositorio atasRepositorio = new AtasRepositorio(str);
                atasRepositorio.Inserir(Atas);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarAtas()
        {
            Atas Atas = new Atas()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_pessoa = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                data = DateTime.Parse("01/01/2099"),
                titulo = "Teste Titulo - altera",
                texto = "Teste Texto - altera"
            };
            try
            {
                AtasRepositorio atasRepositorio = new AtasRepositorio(str);
                atasRepositorio.Alterar(Atas);
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
                AtasRepositorio atasRepositorio = new AtasRepositorio(str);
                atasRepositorio.Excluir(Id);
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
                AtasRepositorio atasRepositorio = new AtasRepositorio(str);
                Atas Atas = atasRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTodasAtasDeUmCondominio()
        {
            Guid Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6");

            try
            {
                AtasRepositorio atasRepositorio = new AtasRepositorio(str);
                List<Atas> Atas = atasRepositorio.ProcurarTodasAtasDeUmCondominio(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
