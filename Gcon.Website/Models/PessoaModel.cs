using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class PessoaEntidade
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public Guid id_condominio { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public string apartamento { get; set; }
        [Required]
        [EmailAddressAttribute]
        public string email { get; set; }
        [Required]
        public string cpf { get; set; }
    }
}