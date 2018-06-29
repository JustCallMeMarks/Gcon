using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gcon.Website.Dominio.Entidade.Pessoa;
using System.Configuration;

namespace Gcon.Website.Repositorio.Teste
{
    [TestClass]
    public class PessoaRepositorioTeste
    {
        string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        [TestMethod]
        public void GravarPessoa()
        {
            Pessoa pessoa = new Pessoa()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                cpf_cnpj = "1234567909",
                nome = "Pessoa Teste",
                apto = "115B",
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                senha = "123456",
                email = "Pessoa@pessoa.com",
                telefone = "5430303030",
                celular = "54998765432",
                permissao = 1,
                status = 1
            };

            try
            {
                PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
                pessoaRepositorio.Inserir(pessoa);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlteraPessoa()
        {
            Pessoa pessoa = new Pessoa()
            {
                id = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                cpf_cnpj = "1234567910",
                nome = "Pessoa Teste - Altera",
                apto = "1150B",
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                senha = "123456 - Altera",
                email = "PessoaAltera@pessoa.com",
                telefone = "1130303030",
                celular = "11998765432",
                permissao = 0,
                status = 0
            };

            try
            {
                PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
                pessoaRepositorio.Alterar(pessoa);
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
                PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
                pessoaRepositorio.Excluir(Id);
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
                PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
                Pessoa pessoa = pessoaRepositorio.Procurar(Id);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
