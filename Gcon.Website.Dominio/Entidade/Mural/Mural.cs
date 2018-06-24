using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Mural
{
    public class Mural
    {
        public Mural()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public string TEXTO { get; set; }
        public DateTime DATA { get; set; }
        public string TITULO { get; set; }
        public Guid ID_PESSOA { get; set; }
    }
}
