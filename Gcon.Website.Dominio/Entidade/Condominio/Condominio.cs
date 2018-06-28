using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Condominio
{
    public class Condominio
    {
        public Condominio()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public int qtd_ap { get; set; }
        public string nome { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public int numero { get; set; }
    }
}
