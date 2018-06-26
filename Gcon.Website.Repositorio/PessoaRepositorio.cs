using System;
using System.Collections.Generic;
using Gcon.Website.Dominio.Entidade.Pessoa;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class PessoaRepositorio : IPessoasRepositorio
    {
        string connectionString;

        public PessoaRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Pessoa Pessoa)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\") " +
                                         " values(@ID, @CPF_CNPJ, @NOME, @APTO, @ID_CONDOMINIO, @SENHA, @EMAIL, @TELEFONE, @CELULAR, @PERMISSAO, @STATUS)", "PESSOAS", "ID", "CPF_CNPJ", "NOME", "APTO", "ID_CONDOMINIO", "SENHA", "EMAIL", "TELEFONE", "CELULAR", "PERMISSAO", "STATUS");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Pessoa.ID);
                comando.Parameters.AddWithValue("CPF_CNPJ", Pessoa.CPF_CNPJ);
                comando.Parameters.AddWithValue("NOME", Pessoa.NOME);
                comando.Parameters.AddWithValue("APTO", Pessoa.APTO);
                comando.Parameters.AddWithValue("ID_CONDOMINIO", Pessoa.ID_CONDOMINIO);
                comando.Parameters.AddWithValue("SENHA", Pessoa.SENHA);
                comando.Parameters.AddWithValue("EMAIL", Pessoa.EMAIL);
                comando.Parameters.AddWithValue("TELEFONE", Pessoa.TELEFONE);
                comando.Parameters.AddWithValue("CELULAR", Pessoa.CELULAR);
                comando.Parameters.AddWithValue("PERMISSAO", Pessoa.PERMISSAO);
                comando.Parameters.AddWithValue("STATUS", Pessoa.STATUS);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Pessoa Pessoa)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\"  = @CPF_CNPJ," +
                                                        "\"{3}\"  = @NOME," +
                                                        "\"{4}\"  = @APTO," +
                                                        "\"{5}\"  = @ID_CONDOMINIO," +
                                                        "\"{6}\"  = @SENHA," +
                                                        "\"{7}\"  = @EMAIL," +
                                                        "\"{8}\"  = @TELEFONE,"+
                                                        "\"{9}\"  = @CELULAR, " +
                                                        "\"{10}\" = @PERMISSAO,"+
                                                        "\"{11}\" = @STATUS "+
                                                    "WHERE \"{1}\" = @ID;", "PESSOAS", "ID", "CPF_CNPJ", "NOME", "APTO", "ID_CONDOMINIO", "SENHA", "EMAIL", "TELEFONE", "CELULAR", "PERMISSAO", "STATUS");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Pessoa.ID.ToString());
                comando.Parameters.AddWithValue("CPF_CNPJ", Pessoa.CPF_CNPJ);
                comando.Parameters.AddWithValue("NOME", Pessoa.NOME);
                comando.Parameters.AddWithValue("APTO", Pessoa.APTO);
                comando.Parameters.AddWithValue("ID_CONDOMINIO", Pessoa.ID_CONDOMINIO);
                comando.Parameters.AddWithValue("SENHA", Pessoa.SENHA);
                comando.Parameters.AddWithValue("EMAIL", Pessoa.EMAIL);
                comando.Parameters.AddWithValue("TELEFONE", Pessoa.TELEFONE);
                comando.Parameters.AddWithValue("CELULAR", Pessoa.CELULAR);
                comando.Parameters.AddWithValue("PERMISSAO", Pessoa.PERMISSAO);
                comando.Parameters.AddWithValue("STATUS", Pessoa.STATUS);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("DELETE FROM \"{0}\"" +
                                                           "WHERE \"{1}\" = @ID;", "PESSOAS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Pessoa Procurar(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                 conexao.Open();
                 NpgsqlCommand comando = new NpgsqlCommand();
                 comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                             "WHERE \"{1}\" = @ID;", "PESSOAS", "ID");
                 comando.Connection = conexao;

                 comando.Parameters.AddWithValue("ID", id.ToString());

                 Pessoa Pessoa = new Pessoa();

                 using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                 {
                     if (SqlData.Read())
                     {
                        Pessoa.ID            = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Pessoa.CPF_CNPJ      = String.Format("{0}", SqlData["CPF_CNPJ"]);
                        Pessoa.NOME          = String.Format("{0}", SqlData["NOME"]);
                        Pessoa.APTO          = String.Format("{0}", SqlData["APTO"]);
                        Pessoa.ID_CONDOMINIO = Guid.Parse(String.Format("{0}", SqlData["ID_CONDOMINIO"]));
                        Pessoa.SENHA         = String.Format("{0}", SqlData["SENHA"]);
                        Pessoa.EMAIL         = String.Format("{0}", SqlData["EMAIL"]);
                        Pessoa.TELEFONE      = String.Format("{0}", SqlData["TELEFONE"]);
                        Pessoa.CELULAR       = String.Format("{0}", SqlData["CELULAR"]);
                        Pessoa.PERMISSAO     = (int) SqlData["PERMISSAO"];
                        Pessoa.STATUS        = (int) SqlData["STATUS"];
                    }
                 }

                 return Pessoa;
             }
        }

        public List<Pessoa> ProcurarTodasAsPessoasDeUmCondominio(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "PESSOAS", "ID_CONDOMINIO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                List<Pessoa> pessoas = new List<Pessoa>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Pessoa Pessoa = new Pessoa();

                        Pessoa.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Pessoa.CPF_CNPJ = String.Format("{0}", SqlData["CPF_CNPJ"]);
                        Pessoa.NOME = String.Format("{0}", SqlData["NOME"]);
                        Pessoa.APTO = String.Format("{0}", SqlData["APTO"]);
                        Pessoa.ID_CONDOMINIO = Guid.Parse(String.Format("{0}", SqlData["ID_CONDOMINIO"]));
                        Pessoa.SENHA = String.Format("{0}", SqlData["SENHA"]);
                        Pessoa.EMAIL = String.Format("{0}", SqlData["EMAIL"]);
                        Pessoa.TELEFONE = String.Format("{0}", SqlData["TELEFONE"]);
                        Pessoa.CELULAR = String.Format("{0}", SqlData["CELULAR"]);
                        Pessoa.PERMISSAO = (int)SqlData["PERMISSAO"];
                        Pessoa.STATUS = (int)SqlData["STATUS"];

                        pessoas.Add(Pessoa);
                    }
                }

                return pessoas;
            }
        }

        public List<Pessoa> ProcurarPessoasApartirEmailSenha(string email , string senha)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\""+
                                                      "from \"{0}\"" +
                                                      "WHERE \"{1}\" <> 3" +
                                                        "AND \"{2}\" = @EMAIL"+
                                                        "AND \"{3}\" = @SENHA;", "SENHA", "PESSOAS", "EMAIL", "ID", "NOME", "ID_CONDOMINIO", "PERMISSAO", "STATUS");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("EMAIL", email);
                comando.Parameters.AddWithValue("SENHA", senha);

                List<Pessoa> pessoas = new List<Pessoa>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Pessoa Pessoa = new Pessoa();

                        Pessoa.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Pessoa.NOME = String.Format("{0}", SqlData["NOME"]);
                        Pessoa.ID_CONDOMINIO = Guid.Parse(String.Format("{0}", SqlData["ID_CONDOMINIO"]));
                        Pessoa.PERMISSAO = (int)SqlData["PERMISSAO"];
                        Pessoa.STATUS = (int)SqlData["STATUS"];

                        pessoas.Add(Pessoa);
                    }
                }

                return pessoas;
            }
        }
    }
}




        
