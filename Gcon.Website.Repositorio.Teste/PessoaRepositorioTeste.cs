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
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                CPF_CNPJ = "1234567909",
                NOME = "Pessoa Teste",
                APTO = "115B",
                ID_CONDOMINIO = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                SENHA = "123456",
                EMAIL = "Pessoa@pessoa.com",
                TELEFONE = "5430303030",
                CELULAR = "54998765432",
                PERMISSAO = 1,
                STATUS = 1
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
                ID = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                CPF_CNPJ = "1234567910",
                NOME = "Pessoa Teste - Altera",
                APTO = "1150B",
                ID_CONDOMINIO = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                SENHA = "123456 - Altera",
                EMAIL = "PessoaAltera@pessoa.com",
                TELEFONE = "1130303030",
                CELULAR = "11998765432",
                PERMISSAO = 0,
                STATUS = 0
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
