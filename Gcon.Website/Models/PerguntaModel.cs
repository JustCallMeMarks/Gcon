using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class PerguntaModel
    {
        public Guid id { get; set; }
        public string pergunta { get; set; }
        public string tipo { get; set; }
        public List<string> Respostas { get; set; }
    }
}