using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcon.Website.Dominio.Entidade.Atas;

namespace Gcon.Website.Dominio.Interface
{
    public interface IAtas
    {
        void Inserir(Atas Atas);
        void Alterar(Atas Atas);
        void Excluir(Guid id);
        Atas Procurar(Guid id);
        List<Atas> ProcurarTodasAtasDeUmCondominio(Guid id);
    }
}
