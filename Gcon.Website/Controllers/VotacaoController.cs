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
    public class VotacaoController : Controller
    {
        // GET: Votacao
        public ActionResult Index()
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
            VotacaoAplicacao votacaoAplicacao = new VotacaoAplicacao(votacoesRepositorio);
            ViewBag.VotacoesCondominio = votacaoAplicacao.getVotacoesCondominio((Guid)Session["Condominio"]);

            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }

        [FiltroAcesso(Tipo = "ADM")]
        public ActionResult NovaVotacao()
        {
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }

        [FiltroAcesso(Tipo = "ADM")]
        public ActionResult AdicionarVotcao(VotacaoModel votacao)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
            VotacaoAplicacao votacaoAplicacao = new VotacaoAplicacao(votacoesRepositorio);

            Dominio.Entidade.Votacoes.Votacoes Votacao = new Dominio.Entidade.Votacoes.Votacoes
            {
                id = Guid.NewGuid(),
                id_condominio = (Guid)Session["Condominio"],
                id_pessoa = (Guid)Session["usuario"],
                data = votacao.data,
                descricao = votacao.objetivo,
                titulo = votacao.titulo,
            };

            votacaoAplicacao.NovaVotacao(Votacao);

            PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio(str);
            PerguntaAplicacao perguntaAplicacao = new PerguntaAplicacao(perguntaRepositorio);

            foreach(PerguntaModel pergunta in votacao.perguntas)
            {
                Dominio.Entidade.Pergunta.Pergunta Pergunta = new Dominio.Entidade.Pergunta.Pergunta
                {
                    id = Guid.NewGuid(),
                    id_votacao = Votacao.id,    
                    pergunta = pergunta.pergunta,
                    resposta = pergunta.Respostas,
                    tipo = pergunta.tipo
                };
                perguntaAplicacao.NovaPergunta(Pergunta);
            }

            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View("NovaVotacao");
        }
    }
}