using Gcon.Website.Aplicacao;
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
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);

            var pessoas = pessoaAplicacao.getMoradores((Guid) Session["Condominio"]);
            ViewBag.Pessoas = pessoas;

            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }
    }
}