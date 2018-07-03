using Gcon.Website.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gcon.Website.Aplicacao;
using Gcon.Website.Dominio.Entidade.Mural;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "USER ADM")]
    public class MuralController : Controller
    {
        // GET: Mural
        public ActionResult Index()
        {
            ViewBag.Texto = TempData.TryGetValue("vlModal", out object Texto).ToString();
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();

            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            MuralRepositorio muralRepositorio = new MuralRepositorio(str);
            MuralAplicacao muralApicacao = new MuralAplicacao(muralRepositorio);

            ViewBag.Mural = muralApicacao.getMural((Guid) Session["Condominio"]);

            ReunioesRepositorio reunioesRepositorio = new ReunioesRepositorio(str);
            ReunioesAplicacao reunioseAplicacao = new ReunioesAplicacao(reunioesRepositorio);

            ViewBag.Reunioes = reunioseAplicacao.getReunioes((Guid)Session["Condominio"]);

            return View();
        }
        public ActionResult EditarAvisos(string Texto, Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            MuralRepositorio muralRepositorio = new MuralRepositorio(str);
            MuralAplicacao muralApicacao = new MuralAplicacao(muralRepositorio);

            DateTime today = default(DateTime);

            Mural mural = new Mural
            {
                id = id,
                id_condominio = (Guid)Session["Condominio"],
                id_pessoa = (Guid)Session["usuario"],
                texto = Texto,
                data = today,
                titulo = "Titulo"
            };

            muralApicacao.setMural(mural);

            //object Permisao = Session["Permission"];
            //ViewBag.Tipo = Permisao.ToString();
            return (RedirectToAction("Index"));
        }
    }
}