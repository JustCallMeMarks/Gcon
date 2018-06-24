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
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int QTD_AP { get; set; }
        public string NOME { get; set; }
        public string RUA { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public string PAIS { get; set; }
        public int NUMERO { get; set; }
    }
}
