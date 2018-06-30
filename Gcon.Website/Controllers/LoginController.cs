using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Gcon.Website.Aplicacao;
using Gcon.Website.Repositorio;
using Gcon.Website.Dominio.Entidade.Pessoa;
using Gcon.Website.Models;

namespace Gcon.Website.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            setViewBag();
            return View();
        }

        public ActionResult Autenticar(string usuario, string senha)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);

            Pessoa pessoa = pessoaAplicacao.Login(usuario, senha);

            if (pessoa != null)
            {
                Session["usuario"] = pessoa.id;
                Session["Permission"] = pessoa.permissao == 1 ? "ADM" : "USER";
                Session["Condominio"] = pessoa.id_condominio;
                return RedirectToAction("Index", "Mural");
            }
            else
            {
                ViewBag.Texto = "Senha ou Email não cadastrado";
            }
            setViewBag();
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            setViewBag();
            return View("Index");
        }

        public ActionResult EsqueciSenha(string email)
        {
            setViewBag();
            return View("Index");
        }

        public ActionResult NovosMoradores(PessoaModel pessoa)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);


            Pessoa pessoaEntidade = new Pessoa()
            {
                nome = pessoa.nome,
                email = pessoa.email,
                telefone = pessoa.telefone,                
                celular = pessoa.celular,
                senha = pessoa.senha,
                id_condominio = pessoa.id_condominio,
                cpf_cnpj = pessoa.cpf,
                apto = pessoa.apartamento
            };

            pessoaAplicacao.Inserir(pessoaEntidade);
            setViewBag();
            return View("Index");
        }

        public void setViewBag()
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            CondominioRepositorio condominioRepositorio = new CondominioRepositorio(str);
            CondominioAplicacao condominioAplicacao = new CondominioAplicacao(condominioRepositorio);

            var condominios = condominioAplicacao.ProcurarTodosCondominios();
            ViewBag.condominios = condominios;
        }
    }
}
