using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Votacoes;

namespace Gcon.Website.Dominio.Interface
{
    public interface IVotacoes
    {
        void Inserir(Votacoes Votacoes);
        void Alterar(Votacoes Votacoes);
        void Excluir(Guid id);
        Votacoes Procurar(Guid id);
    }
}
