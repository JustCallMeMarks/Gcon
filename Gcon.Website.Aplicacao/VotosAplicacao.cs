using Gcon.Website.Dominio.Entidade.Votos;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Aplicacao
{
    public class VotosAplicacao
    {
        IVotos Votos;

        public VotosAplicacao(IVotos votos)
        {
            this.Votos = votos;
        }

        public void Votar(Votos voto)
        {
            this.Votos.Inserir(voto);
        }

        public void ResultadoVotacao(Guid id)
        {
            //this.Votos.;
        }
    }
}
