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
            if ( string.IsNullOrEmpty(pessoa.CPF_CNPJ) )
            {
                throw new ApplicationException("Cpf invalido");
            }

            this.pessoaRepossitorio.Inserir(pessoa);
        }

    }
}
