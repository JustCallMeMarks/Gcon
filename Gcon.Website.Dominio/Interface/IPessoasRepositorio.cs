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
        void Inserir(Pessoa Pessoa);
        void Alterar(Pessoa Pessoa);
        void Excluir(Guid id);
        Pessoa Procurar(Guid id);
        List<Pessoa> ProcurarTodasAsPessoasDeUmCondominio(Guid id);
    }
}
