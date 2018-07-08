using Gcon.Website.Dominio.Entidade.Atas;
using Gcon.Website.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcon.Website.Aplicacao
{
    public class AtasAplicacao
    {
        IAtas AtasRepositorio;

        public AtasAplicacao(IAtas atasRepositorio)
        {
            this.AtasRepositorio = atasRepositorio;
        }

        public List<Atas> getAtas(Guid id)
        {
            return this.AtasRepositorio.ProcurarTodasAtasDeUmCondominio(id);
        }

        public Atas getAta(Guid id)
        {
            return this.AtasRepositorio.Procurar(id);
        }

        public void excluir(Guid id)
        {
            this.AtasRepositorio.Excluir(id);
        }

        public void Adicionar(Atas atas)
        {
            if(!this.AtasRepositorio.Alterar(atas))
            {
                this.AtasRepositorio.Inserir(atas);
            }
        }
    }
}
