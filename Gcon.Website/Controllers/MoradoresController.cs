using Gcon.Website.Aplicacao;
using Gcon.Website.Dominio.Entidade.Pessoa;
using Gcon.Website.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "ADM")]
    public class MoradoresController : Controller
    {
        // GET: Moradores
        public ActionResult Index()
        {
            int i = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                i = Int32.Parse(Request.QueryString["i"]);
            }
            var pessoas = procuraPessoas();
            ViewBag.pessoasNAprovadas = pessoas.FindAll(pessoa => pessoa.status == 0);
            pessoas.RemoveAll(pessoa => pessoa.status == 0);
            ViewBag.QtdPessoa = pessoas.Count;

            if (i < 0)
                i = 0;
            if (pessoas.Count < i)
                i = pessoas.Count - (pessoas.Count % 5);
            pessoas = pessoas.GetRange(i, (pessoas.Count - i) < 5 ? (pessoas.Count - i) % 5 : 5);
            ViewBag.Pessoas = pessoas;

            ViewBag.PagAtual = i;
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            ViewBag.Action = "Index";
            return View();
        }

        public List<Dominio.Entidade.Pessoa.PessoaEntidade> procuraPessoas()
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);

            var pessoas = pessoaAplicacao.getMoradores((Guid)Session["Condominio"]);
            return pessoas;
        }

        public ActionResult Pesquisa(string nome)
        {
            int i = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["i"]))
            {
                i = Int32.Parse(Request.QueryString["i"]);
            }
            var pessoas = procuraPessoas();
            ViewBag.pessoasNAprovadas = pessoas.FindAll(pessoa => pessoa.status == 0);
            pessoas.RemoveAll(pessoa => pessoa.status == 0);

            pessoas = pessoas.FindAll(x => x.nome.Contains(nome));
            ViewBag.QtdPessoa = pessoas.Count;
            if (i < 0)
                i = 0;
            if (pessoas.Count < i)
                i = pessoas.Count - (pessoas.Count % 5);
            pessoas = pessoas.GetRange(i, (pessoas.Count - i) < 5 ? (pessoas.Count - i) % 5 : 5);
            ViewBag.Pessoas = pessoas;
            ViewBag.PagAtual = i;
            ViewBag.Action = "Pesquisa";
            ViewBag.pesquisa = nome;
            return View("Index");
        }

        public ActionResult MostraPessoa(Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);
            var pessoa = pessoaAplicacao.Procura(id);
            ViewBag.pessoaSelecionada = pessoa;
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

        public ActionResult Bloquear(Guid id)
        {
            mudaStatus(id,"2");

            Index();
            return View("Index");
        }

        public ActionResult Desbloquear(Guid id)
        {
            mudaStatus(id, "1");

            Index();
            return View("Index");
        }

        public void mudaStatus(Guid id, string status)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);

            pessoaAplicacao.bloqueia(id,status);
        }

        public ActionResult EditarApto(Guid id, string apto)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);
            PessoaEntidade pessoa = pessoaAplicacao.Procura(id);
            pessoa.apto = apto;
            pessoaAplicacao.Altera(pessoa);

            Index();
            return View("Index");
        }
    }
}