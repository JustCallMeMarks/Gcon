using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class Votos
    {
        public Guid id {get; set;}
        public Guid id_pergunta { get; set; }
        public Guid id_pessoa { get; set; }
        public string resposta { get; set; }
    }
}