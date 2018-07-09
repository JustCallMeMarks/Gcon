using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Dominio.Entidade.Resultado;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Aplicacao
{
    public class PerguntaAplicacao
    {
        IPerguntas Perguntas;

        public PerguntaAplicacao(IPerguntas perguntas)
        {
            this.Perguntas = perguntas;
        }

        public void NovaPergunta(Pergunta pergunta)
        {
            this.Perguntas.Inserir(pergunta);
        }

        public List<Resultado> ContarVotosPergunta(Guid id)
        {
            return this.Perguntas.ContarVotosPergunta(id);
        }
    }
}
