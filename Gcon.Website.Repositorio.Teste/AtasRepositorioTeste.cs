using System;
using Gcon.Website.Dominio.Entidade.Atas;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gcon.Website.Repositorio.Teste;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class AtasRepositorioTeste
    {
        [TestMethod]
        public void GravarAtas()
        {
            Atas Atas = new Atas()
            {
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("01/01/2018"),
                TITULO = "Teste Titulo",
                TEXTO = "Teste Texto"
            };
            try
            {
                AtasRepositorio atasRepositorio = new AtasRepositorio(StringConexao.Conexao());
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
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                ID_PESSOA = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                DATA = DateTime.Parse("31/12/2100"),
                TITULO = "Teste Titulo - Alterado",
                TEXTO = "Teste Texto - Alterado"
            };
            try
            {
                AtasRepositorio atasRepositorio = new AtasRepositorio(StringConexao.Conexao());
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
                AtasRepositorio atasRepositorio = new AtasRepositorio(StringConexao.Conexao());
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
                AtasRepositorio atasRepositorio = new AtasRepositorio(StringConexao.Conexao());
                Atas Atas = atasRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
