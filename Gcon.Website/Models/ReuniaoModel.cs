using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gcon.Website.Models
{
    public class ReuniaoModel
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public Guid id_condominio { get; set; }
        [Required]
        public Guid id_pessoa { get; set; }
        public DateTime data { get; set; }
        public String titulo { get; set; }
    }
}