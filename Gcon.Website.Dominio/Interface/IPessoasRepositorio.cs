using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Pessoa;

namespace Gcon.Website.Dominio.Interface
{
    public interface IPessoasRepositorio
    {
        void Inserir(PessoaEntidade Pessoa);
        void Alterar(PessoaEntidade Pessoa);
        void Excluir(Guid id);
        PessoaEntidade Procurar(Guid id);
        List<PessoaEntidade> ProcurarTodasAsPessoasDeUmCondominio(Guid id);
        PessoaEntidade ProcurarPessoasApartirEmailSenha(string email, string senha);
        void Bloqueia(Guid id);
    }
}
