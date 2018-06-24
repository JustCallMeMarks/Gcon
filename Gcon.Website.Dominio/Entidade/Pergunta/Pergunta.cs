using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Pergunta
{
    public class Pergunta
    {
        public Pergunta()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public Guid ID_VOTACAO { get; set; }
        public string PERGUNTA { get; set; }
        public string TIPO { get; set; }
    }
}
