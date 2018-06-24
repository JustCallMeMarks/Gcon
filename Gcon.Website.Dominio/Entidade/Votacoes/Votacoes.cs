using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Votacoes
{
    public class Votacoes
    {
        public Votacoes()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATA { get; set; }
        public Guid ID_PESSOA { get; set; }
        public string TITULO { get; set; }
    }
}
