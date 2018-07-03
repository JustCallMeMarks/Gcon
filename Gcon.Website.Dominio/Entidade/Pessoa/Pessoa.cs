using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Dominio.Entidade.Pessoa
{
    public class PessoaEntidade
    {
        public PessoaEntidade()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string cpf_cnpj { get; set; }
        public string nome { get; set; }
        public string apto { get; set; }
        public Guid id_condominio { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int permissao { get; set; }
        public int status { get; set; }
    }
}
