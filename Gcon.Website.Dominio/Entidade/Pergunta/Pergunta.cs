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
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public Guid id_votacao { get; set; }
        public string pergunta { get; set; }
        public string tipo { get; set; }
    }
}
