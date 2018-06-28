using System;
using Gcon.Website.Dominio.Entidade.Condominio;
using Gcon.Website.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace TesteCondominioRepositorio
{
    [TestClass]
    public class TesteCondominioRepositorio
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarTest()
        {
            Condominio condominio = new Condominio()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                qtd_ap  = 100,
                nome = "Condominio Teste",
                rua = "Rua dos Condominios",
                bairro = "Parque da Pedra",
                cidade = "Caxias do Sul",
                estado = "Rio Grande do Sul",
                pais = "Brasil",
                numero = 119
            };

            try
            {
                CondominioRepositorio condominioRepositorio = new CondominioRepositorio(str);
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
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                qtd_ap = 1000,
                nome = "Condominio Teste - Altera",
                rua = "Rua dos Condominios - Altera",
                bairro = "Parque da Pedra - Altera",
                cidade = "Caxias do Sul - Altera",
                estado = "Rio Grande do Sul - Altera",
                pais = "Brasil - Altera",
                numero = 1190
            };

            try
            {
                CondominioRepositorio produtoRepository = new CondominioRepositorio(str);
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
                CondominioRepositorio produtoRepository = new CondominioRepositorio(str);
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
                CondominioRepositorio produtoRepository = new CondominioRepositorio(str);
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
