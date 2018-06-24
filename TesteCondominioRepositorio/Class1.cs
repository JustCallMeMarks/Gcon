using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteCondominioRepositorio
{
    [TestClass]
    public class TesteCondominioRepositorio
    {
        [TestMethod]
        public void GravarTest()
        {
            Produto produto = new Produto()
            {
                CategoriaId = Guid.NewGuid(),
                Descricao = "Teste",
                Id = Guid.NewGuid(),
                Nome = "Teste",
                Preco = 10,
                Quantidade = 1
            };

            try
            {
                ProdutoRepository produtoRepository = new ProdutoRepository("Server=127.0.0.1;Port=5432;Database=Gcon;User Id=postgres;Password = Privada123; ");
                produtoRepository.Inserir(produto);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
