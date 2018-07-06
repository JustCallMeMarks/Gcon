using Gcon.Website.Dominio.Entidade.Reunioes;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace Gcon.Website.Aplicacao
{
    public class ReunioesAplicacao
    {
        IReunioes reunioes;

        public ReunioesAplicacao(IReunioes reunioes)
        {
            this.reunioes = reunioes;
        }

        public List<Reunioes> getReunioes(Guid id)
        {
            return this.reunioes.ProcurarTodasReunioesDeUmCondominio(id);
        }

        public void setReunioes(Reunioes reuniao)
        {
            if(!this.reunioes.Alterar(reuniao))
            {
                this.reunioes.Inserir(reuniao);
            }
        }
    }
}
