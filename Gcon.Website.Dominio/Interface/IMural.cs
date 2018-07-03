using System;
using System.Collections.Generic;
using Gcon.Website.Dominio.Entidade.Mural;

namespace Gcon.Website.Dominio.Interface
{
    public interface IMural
    {
        void Inserir(Mural Mural);
        bool Alterar(Mural Mural);
        void Excluir(Guid id);
        Mural Procurar(Guid id);
        List<Mural> ProcurarMuralDoCondominio(Guid id);
    }
}
