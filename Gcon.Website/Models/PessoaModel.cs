using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class PessoaModel
    {
        public string nome { get; set; }
        public Guid id_condominio { get; set; }
        public string telefone { get; set; } 
        public string celular { get; set; }
        public string senha { get; set; }
        public string apartamento { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
    }
}