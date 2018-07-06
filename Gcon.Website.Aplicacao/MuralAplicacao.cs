using Gcon.Website.Dominio.Entidade.Mural;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace Gcon.Website.Aplicacao
{
    public class MuralAplicacao
    {

        IMural muralRepositorio;

        public MuralAplicacao(IMural muralRepositorio)
        {
            this.muralRepositorio = muralRepositorio;
        }

        public List<Mural> getMural(Guid id)
        {
            return this.muralRepositorio.ProcurarMuralDoCondominio(id);
        }

        public void setMural(Mural mural)
        {
            if (!muralRepositorio.Alterar(mural))
            {
                this.muralRepositorio.Inserir(mural);
            }
        }

        public void Apagar(Guid id)
        {
            this.muralRepositorio.Excluir(id);
        }
    }
}
