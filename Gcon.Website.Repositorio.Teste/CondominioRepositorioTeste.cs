using System;
using Gcon.Website.Dominio.Entidade.Condominio;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TesteCondominioRepositorio
{
    [TestClass]
    public class TesteCondominioRepositorio
    {
        [TestMethod]
        public void GravarTest()
        {
            Condominio condominio = new Condominio()
            {
                Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                QTD_AP = 100,
                NOME = "Condominio Teste",
                RUA = "Rua dos Condominios",
                BAIRRO = "Parque da Pedra",
                CIDADE = "Caxias do Sul",
                ESTADO = "Rio Grande do Sul",
                PAIS = "Brasil",
                NUMERO = 119
            };

            try
            {
                CondominioRepositorio condominioRepositorio = new CondominioRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                condominioRepositorio.Inserir(condominio);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Modifica()
        {
            Condominio condominio = new Condominio()
            {
                Id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                QTD_AP = 1000,
                NOME = "Condominio Teste - Altera",
                RUA = "Rua dos Condominios - Altera",
                BAIRRO = "Parque da Pedra - Altera",
                CIDADE = "Caxias do Sul - Altera",
                ESTADO = "Rio Grande do Sul - Altera",
                PAIS = "Brasil - Altera",
                NUMERO = 1190
            };

            try
            {
                CondominioRepositorio produtoRepository = new CondominioRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                produtoRepository.Alterar(condominio);
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
                CondominioRepositorio produtoRepository = new CondominioRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                produtoRepository.Excluir(Id);
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
                CondominioRepositorio produtoRepository = new CondominioRepositorio("Server=localhost;Port=5432;Database=Gcon;User Id=postgres;Password=Gcon123;");
                Condominio condominio = produtoRepository.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
