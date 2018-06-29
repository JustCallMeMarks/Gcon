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
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public Guid id_pessoa { get; set; }
        public Guid id_pergunta { get; set; }
        public string resposta { get; set; }
    }
}
