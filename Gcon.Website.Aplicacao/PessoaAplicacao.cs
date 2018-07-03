using System;
using System.Collections.Generic;
using Gcon.Website.Dominio.Entidade.Pessoa;
using Gcon.Website.Dominio.Interface;

namespace Gcon.Website.Aplicacao
{
    public class PessoaAplicacao
    {

        IPessoasRepositorio pessoaRepossitorio;

        public PessoaAplicacao(IPessoasRepositorio pessoaRepossitorio)
        {
            this.pessoaRepossitorio = pessoaRepossitorio;
        }

        public void Inserir(PessoaEntidade pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.nome))
            {
                throw new ApplicationException("Nome invalido");
            }
            if (string.IsNullOrEmpty(pessoa.cpf_cnpj))
            {
                throw new ApplicationException("CPF invalido");
            }
            else
            {
                pessoa.cpf_cnpj = SemFormatacao(pessoa.cpf_cnpj);
                if(!ValidarCpf(pessoa.cpf_cnpj))
                {
                    throw new ApplicationException("CPF invalido");
                }
            }
            if (string.IsNullOrEmpty(pessoa.apto))
            {
                throw new ApplicationException("Apartamento invalido");
            }
            if (string.IsNullOrEmpty(pessoa.email) || !pessoa.email.Contains("@") || !pessoa.email.Contains("."))
            {
                throw new ApplicationException("Email invalido");
            }
            if (string.IsNullOrEmpty(pessoa.id_condominio.ToString()))
            {
                throw new ApplicationException("Apartamento invalido");
            }
            if (string.IsNullOrEmpty(pessoa.senha) || pessoa.senha.Length < 8)
            {
                throw new ApplicationException("Senha invalido");
            }
            pessoa.telefone = SemFormatacao(pessoa.telefone);
            pessoa.celular = SemFormatacao(pessoa.celular);
            pessoa.status = 0;
            pessoa.permissao = 0;
            this.pessoaRepossitorio.Inserir(pessoa);
        }

        public PessoaEntidade Login(string email, string senha)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                throw new ApplicationException("Insira Email e senha");
            }

            return this.pessoaRepossitorio.ProcurarPessoasApartirEmailSenha(email,senha);
        }

        public List<PessoaEntidade> getMoradores(Guid id)
        {
            return this.pessoaRepossitorio.ProcurarTodasAsPessoasDeUmCondominio(id);
        }

        public PessoaEntidade Procura(Guid id)
        {
            return this.pessoaRepossitorio.Procurar(id);
        }

        public Boolean ValidarCpf(String CPF)
        {
            int Soma;
            int Resto;
            Soma = 0;
            if (CPF == "00000000000")
                return false;
            for (int i = 1; i <= 9; i++)
                Soma = Soma + Int32.Parse(CPF.Substring(i - 1, 1)) * (11 - i);
            Resto = (Soma * 10) % 11;
            if ((Resto == 10) || (Resto == 11))
                Resto = 0;
            if (Resto != Int32.Parse(CPF.Substring(9, 1)))
                return false;
            Soma = 0;
            for (int i = 1; i <= 10; i++)
                Soma = Soma + Int32.Parse(CPF.Substring(i - 1, 1)) * (12 - i);
            Resto = (Soma * 10) % 11;
            if ((Resto == 10) || (Resto == 11))
                Resto = 0;
            if (Resto != Int32.Parse(CPF.Substring(10, 1)))
                return false;
            return true;
        }

        public static string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace("(",string.Empty).Replace(") ", string.Empty);
        }

        public void ExcluirMorador(Guid id)
        {
            this.pessoaRepossitorio.Excluir(id);
        }

        public void bloqueia(Guid id)
        {
            this.pessoaRepossitorio.Bloqueia(id);
        }

        public void Altera(PessoaEntidade pessoa)
        {
            this.pessoaRepossitorio.Alterar(pessoa);
        }
    }
}
