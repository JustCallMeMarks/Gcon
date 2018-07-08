using Gcon.Website.Aplicacao;
using Gcon.Website.Models;
using Gcon.Website.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "USER ADM")]
    public class AtasController : Controller
    {
        // GET: Atas
        public ActionResult Index()
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            AtasRepositorio atasRepositorio = new AtasRepositorio(str);
            AtasAplicacao atasAplicacao = new AtasAplicacao(atasRepositorio);

            var atas = atasAplicacao.getAtas((Guid)Session["Condominio"]);

            object Permisao = Session["Permission"];

            ViewBag.Ata  = new AtasModel();
            ViewBag.Atas = atas;
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }

        public ActionResult Apagar(Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            AtasRepositorio atasRepositorio = new AtasRepositorio(str);
            AtasAplicacao atasAplicacao = new AtasAplicacao(atasRepositorio);

            atasAplicacao.excluir(id);
            return RedirectToAction("Index", "Atas");
        }

        public ActionResult AdicionarAta(string titulo)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            AtasRepositorio atasRepositorio = new AtasRepositorio(str);
            AtasAplicacao atasAplicacao = new AtasAplicacao(atasRepositorio);

            Dominio.Entidade.Atas.Atas ata = new Dominio.Entidade.Atas.Atas()
            {
                id_condominio = (Guid)Session["Condominio"],
                id_pessoa = (Guid)Session["usuario"],
                data = DateTime.Now,
                titulo = titulo,
                texto = ""
            };

            atasAplicacao.Adicionar(ata);
            return RedirectToAction("Index", "Atas");
        }

        public ActionResult Selecionar(Guid id)
        { 
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            AtasRepositorio atasRepositorio = new AtasRepositorio(str);
            AtasAplicacao atasAplicacao = new AtasAplicacao(atasRepositorio);
            Index();

            ViewBag.Ata = atasAplicacao.getAta(id);
            return View("Index");
        }

        public ActionResult EditarAta(AtasModel Ata)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            AtasRepositorio atasRepositorio = new AtasRepositorio(str);
            AtasAplicacao atasAplicacao = new AtasAplicacao(atasRepositorio);

            Dominio.Entidade.Atas.Atas ata = new Dominio.Entidade.Atas.Atas()
            {
                id = Ata.id,
                id_condominio = (Guid)Session["Condominio"],
                id_pessoa = (Guid)Session["usuario"],
                data = Ata.data,
                titulo = Ata.titulo,
                texto = Ata.texto
            };

            atasAplicacao.Adicionar(ata);
            return RedirectToAction("Selecionar", "Atas", new { Ata.id });
        }
    }
}