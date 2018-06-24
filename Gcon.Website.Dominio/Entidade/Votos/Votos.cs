using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Votos
{
    public class Votos
    {
        public Votos()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public Guid ID_PESSOA { get; set; }
        public Guid ID_PERGUNTA { get; set; }
        public string RESPOSTA { get; set; }
    }
}
