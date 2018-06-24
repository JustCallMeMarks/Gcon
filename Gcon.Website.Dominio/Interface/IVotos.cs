using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Votos;

namespace Gcon.Website.Dominio.Interface
{
    public interface IVotos
    {
        void Inserir(Votos Atas);
        void Alterar(Votos Atas);
        void Excluir(Guid id);
        Votos Procurar(Guid id);
    }
}
