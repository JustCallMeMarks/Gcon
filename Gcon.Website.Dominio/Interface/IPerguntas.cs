using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Pergunta;

namespace Gcon.Website.Dominio.Interface
{
    public interface IPerguntas
    {
        void Inserir(Pergunta Atas);
        void Alterar(Pergunta Atas);
        void Excluir(Guid id);
        Pergunta Procurar(Guid id);
    }
}
