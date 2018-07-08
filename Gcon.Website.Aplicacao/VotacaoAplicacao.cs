using Gcon.Website.Dominio.Entidade.Votacoes;
using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Aplicacao
{
    public class VotacaoAplicacao
    {
        IVotacoes Votacoes;

        public VotacaoAplicacao(IVotacoes votacoes)
        {
            this.Votacoes = votacoes;
        }

        public void NovaVotacao(Votacoes votacao)
        {
            this.Votacoes.Inserir(votacao);
        }

        public List<Votacoes> getVotacoesCondominio(Guid id)
        {
            return this.Votacoes.ProcurarTodasVotacoesDeUmCondominio(id);
        }

        public Votacoes getVotacoes(Guid id)
        {
            return this.Votacoes.Procurar(id);
        }

        public List<Pergunta> getPerguntas(Guid id)
        {
            return this.Votacoes.TodasPerguntasDeUmaVotacao(id);
        }
    }
}

