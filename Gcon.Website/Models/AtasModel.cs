using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class AtasModel
    {
        public Guid id { get; set; }
        public Guid id_pessoa { get; set; }
        public Guid id_condominio { get; set; }
        public DateTime data { get; set; }
        public string texto { get; set; }
        public string titulo { get; set; }
    }
}