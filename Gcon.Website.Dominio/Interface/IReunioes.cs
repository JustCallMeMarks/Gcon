using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Reunioes;

namespace Gcon.Website.Dominio.Interface
{
    public interface IReunioes
    {
        void Inserir(Reunioes Reunioes);
        void Alterar(Reunioes Reunioes);
        void Excluir(Guid id);
        Reunioes Procurar(Guid id);
    }
}
