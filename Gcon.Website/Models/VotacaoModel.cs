using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class VotacaoModel
    {
        public Guid id { get; set; }
        public Guid id_pessoa { get; set; }
        public Guid id_condominio { get; set; }
        public string titulo { get; set; }
        public string objetivo { get; set; }
        public DateTime data { get; set; }
        public List<PerguntaModel> perguntas { get; set; }
    }
}