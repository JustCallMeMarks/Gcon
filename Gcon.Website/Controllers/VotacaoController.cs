using Gcon.Website.Aplicacao;
using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Dominio.Entidade.Resultado;
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

        public ActionResult Selecionar(Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
            VotacaoAplicacao votacaoAplicacao = new VotacaoAplicacao(votacoesRepositorio);
            ViewBag.Votacao = votacaoAplicacao.getVotacoes(id);
            ViewBag.Perguntas = votacaoAplicacao.getPerguntas(id);

            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            Index();
            return View("Index");
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

        public ActionResult Votar(List<Votos> Votos)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            VotosRepositorio votosRepositorio = new VotosRepositorio(str);
            VotosAplicacao votosAplicacao = new VotosAplicacao(votosRepositorio);

            foreach (Votos voto in Votos)
            {
                Dominio.Entidade.Votos.Votos Voto = new Dominio.Entidade.Votos.Votos
                {
                    id_pergunta = voto.id_pergunta,
                    id_pessoa = (Guid)Session["usuario"],
                    resposta = voto.resposta
                };
                votosAplicacao.Votar(Voto);
            }
            Index();
            return View("Index");
        }

        [FiltroAcesso(Tipo = "ADM")]
        public ActionResult Resultado(Guid id)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            VotacoesRepositorio votacoesRepositorio = new VotacoesRepositorio(str);
            VotacaoAplicacao votacaoAplicacao = new VotacaoAplicacao(votacoesRepositorio);

            List<Pergunta> Perguntas = votacaoAplicacao.getPerguntas(id);

            PerguntaRepositorio perguntaRepositorio = new PerguntaRepositorio(str);
            PerguntaAplicacao perguntaAplicacao = new PerguntaAplicacao(perguntaRepositorio);

            List<Resultado> resultados = new List<Resultado>();
            foreach (Pergunta pergunta in Perguntas)
            {
                List<Resultado> resultadosUma = perguntaAplicacao.ContarVotosPergunta(pergunta.id);
                foreach(Resultado resultado in resultadosUma)
                {
                    resultado.id_pergunta = pergunta.id;
                }
                resultados.AddRange(resultadosUma);
            }
            ViewBag.Votacao = votacaoAplicacao.getVotacoes(id);
            ViewBag.VotacoesCondominio = votacaoAplicacao.getVotacoesCondominio((Guid)Session["Condominio"]);
            ViewBag.Perguntas = Perguntas;
            ViewBag.Resultado = resultados;
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View("Index");
        }
    }
}