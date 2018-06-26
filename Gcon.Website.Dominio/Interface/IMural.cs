using System;
using Gcon.Website.Dominio.Entidade.Mural;

namespace Gcon.Website.Dominio.Interface
{
    public interface IMural
    {
        void Inserir(Mural Mural);
        void Alterar(Mural Mural);
        void Excluir(Guid id);
        Mural Procurar(Guid id);
        Mural ProcurarMuralDoCondominio(Guid id)
    }
}
