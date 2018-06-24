using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Pessoa
{
    public class Pessoa
    {
        public Pessoa()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public string CPF_CNPJ { get; set; }
        public string NOME { get; set; }
        public string APTO { get; set; }
        public Guid ID_CONDOMINIO { get; set; }
        public string SENHA { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string CELULAR { get; set; }
        public int PERMISSAO { get; set; }
        public int STATUS { get; set; }
    }
}
