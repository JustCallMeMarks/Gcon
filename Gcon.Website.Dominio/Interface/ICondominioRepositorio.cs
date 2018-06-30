using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Condominio;

namespace Gcon.Website.Dominio.Interface
{
    public interface ICondominioRepositorio
    {
        void Inserir(Condominio Condominio);
        void Alterar(Condominio Condominio);
        void Excluir(Guid id);
        Condominio Procurar(Guid id);
        List<Condominio> ProcurarTodosCondominios();
    }
}
