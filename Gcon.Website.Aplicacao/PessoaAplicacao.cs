using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade;
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

        public void Inserir(Pessoa pessoa)
        {
            if ( string.IsNullOrEmpty(pessoa.cpf_cnpj) )
            {
                throw new ApplicationException("Cpf invalido");
            }

            this.pessoaRepossitorio.Inserir(pessoa);
        }

        public Pessoa Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                throw new ApplicationException("Insira Email e senha");
            }

            return this.pessoaRepossitorio.ProcurarPessoasApartirEmailSenha(email,senha);
        }

        public List<Pessoa> getMoradores(Guid id)
        {
            return this.pessoaRepossitorio.ProcurarTodasAsPessoasDeUmCondominio(id);
        }

    }
}
