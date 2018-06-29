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
                return RedirectToAction("Index", "Mural");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return View("Index");
        }

        public ActionResult EsqueciSenha(string email)
        {
            return View("Index");
        }

        public ActionResult NovosMoradores(string nome, string email, string tel, string cel, string senha, string condominio, string cpf, string apartamento)
        {
            string str = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio(str);
            PessoaAplicacao pessoaAplicacao = new PessoaAplicacao(pessoaRepositorio);


            Pessoa pessoa = new Pessoa()
            {
                nome = nome,
                email = email,
                telefone = tel,                
                celular = cel,
                senha = senha,
                id_condominio = Guid.Parse("7edafe64-f996-4ba9-8f8c-2eb1367a6ca6"),
                cpf_cnpj = cpf,
                apto = apartamento
            };

            pessoaAplicacao.Inserir(pessoa);

            return View("Index");
        }
    }
}
