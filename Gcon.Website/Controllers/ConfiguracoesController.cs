using Gcon.Website.Aplicacao;
using Gcon.Website.Dominio.Entidade.Pessoa;
using Gcon.Website.Repositorio;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "USER ADM")]
    public class ConfiguracoesController : Controller
    {
        // GET: Configuracoes
        public ActionResult Index()
        {
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();

            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);
            var pessoa = pessoaAplicacao.Procura((Guid) Session["usuario"]);
            ViewBag.pessoa = pessoa;
            return View();
        }

        public ActionResult Alterar(PessoaEntidade pessoa, string senha)
        {
            pessoa.id = (Guid) Session["usuario"];
            pessoa.id_condominio = (Guid) Session["Condominio"];
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);
            if (pessoaAplicacao.Login(pessoa.email, senha) != null)
            {
                if(pessoa.senha == null)
                {
                    pessoa.senha = senha;
                }
                object Permisao = Session["Permission"];
                pessoa.permissao = Permisao.ToString() == "ADM" ? 1:0;
                pessoa.status = 1;
                pessoaAplicacao.Altera(pessoa);
            }
            Index();
            return View("Index");
        }

        public ActionResult Excluir(Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);
            pessoaAplicacao.ExcluirMorador(id);
            Index();
            return View("Index");
        }
    }
}