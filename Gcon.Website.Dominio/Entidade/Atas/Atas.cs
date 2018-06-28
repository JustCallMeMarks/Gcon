using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Atas
{
    public class Atas
    {
        public Atas()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string texto { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public Guid id_pessoa { get; set; }
        public Guid id_condominio { get; set; }
    }
}
