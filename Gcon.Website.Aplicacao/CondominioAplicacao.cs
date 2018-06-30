using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade;
using Gcon.Website.Dominio.Entidade.Condominio;
using Gcon.Website.Dominio.Interface;

namespace Gcon.Website.Aplicacao
{
    public class CondominioAplicacao
    {
        ICondominioRepositorio condominioRepositorio;

        public CondominioAplicacao(ICondominioRepositorio condominioRepositorio)
        {
            this.condominioRepositorio = condominioRepositorio;
        }

        public List<Condominio> ProcurarTodosCondominios()
        {
            return this.condominioRepositorio.ProcurarTodosCondominios();
        }
    }
}
