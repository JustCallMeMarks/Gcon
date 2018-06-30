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
                comando.CommandText = "INSERT INTO pessoas (id, cpf_cnpj, nome, apto, id_condominio, senha, email, telefone, celular, permissao, status) " +
                                         " VALUES(@id, @cpf_cnpj, @nome, @apto, @id_condominio, @senha, @email, @telefone, @celular, @permissao, @status)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pessoa.id);
                comando.Parameters.AddWithValue("cpf_cnpj", Pessoa.cpf_cnpj);
                comando.Parameters.AddWithValue("nome", Pessoa.nome);
                comando.Parameters.AddWithValue("apto", Pessoa.apto);
                comando.Parameters.AddWithValue("id_condominio", Pessoa.id_condominio);
                comando.Parameters.AddWithValue("senha", Pessoa.senha);
                comando.Parameters.AddWithValue("email", Pessoa.email);
                comando.Parameters.AddWithValue("telefone", Pessoa.telefone);
                comando.Parameters.AddWithValue("celular", Pessoa.celular);
                comando.Parameters.AddWithValue("permissao", Pessoa.permissao);
                comando.Parameters.AddWithValue("status", Pessoa.status);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Pessoa Pessoa)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE pessoas " +
                                         "SET cpf_cnpj = @cpf_cnpj," +
                                                 "nome = @nome," +
                                                 "apto = @apto," +
                                        "id_condominio = @id_condominio," +
                                                "senha = @senha," +
                                                "email = @email," +
                                             "telefone = @telefone," +
                                              "celular = @celular, " +
                                            "permissao = @permissao," +
                                               "status = @status " +
                                             "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pessoa.id.ToString());
                comando.Parameters.AddWithValue("cpf_cnpj", Pessoa.cpf_cnpj);
                comando.Parameters.AddWithValue("nome", Pessoa.nome);
                comando.Parameters.AddWithValue("apto", Pessoa.apto);
                comando.Parameters.AddWithValue("id_condominio", Pessoa.id_condominio.ToString());
                comando.Parameters.AddWithValue("senha", Pessoa.senha);
                comando.Parameters.AddWithValue("email", Pessoa.email);
                comando.Parameters.AddWithValue("telefone", Pessoa.telefone);
                comando.Parameters.AddWithValue("celular", Pessoa.celular);
                comando.Parameters.AddWithValue("permissao", Pessoa.permissao);
                comando.Parameters.AddWithValue("status", Pessoa.status);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM pessoas " +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Pessoa Procurar(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                 conexao.Open();
                 NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM pessoas " +
                                              "WHERE id = @id;";
                 comando.Connection = conexao;

                 comando.Parameters.AddWithValue("id", id.ToString());

                 Pessoa Pessoa = new Pessoa();

                 using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                 {
                     if (SqlData.Read())
                     {
                        Pessoa.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Pessoa.cpf_cnpj = String.Format("{0}", SqlData["cpf_cnpj"]);
                        Pessoa.nome = String.Format("{0}", SqlData["nome"]);
                        Pessoa.apto = String.Format("{0}", SqlData["apto"]);
                        Pessoa.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                        Pessoa.senha = String.Format("{0}", SqlData["senha"]);
                        Pessoa.email = String.Format("{0}", SqlData["email"]);
                        Pessoa.telefone = String.Format("{0}", SqlData["telefone"]);
                        Pessoa.celular = String.Format("{0}", SqlData["celular"]);
                        Pessoa.permissao = (int) SqlData["permissao"];
                        Pessoa.status = (int) SqlData["status"];
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
                comando.CommandText = "SELECT * FROM pessoas " +
                                              "WHERE id_condominio = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Pessoa> pessoas = new List<Pessoa>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Pessoa Pessoa = new Pessoa();


                        Pessoa.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Pessoa.cpf_cnpj = String.Format("{0}", SqlData["cpf_cnpj"]);
                        Pessoa.nome = String.Format("{0}", SqlData["nome"]);
                        Pessoa.apto = String.Format("{0}", SqlData["apto"]);
                        Pessoa.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                        Pessoa.senha = String.Format("{0}", SqlData["senha"]);
                        Pessoa.email = String.Format("{0}", SqlData["email"]);
                        Pessoa.telefone = String.Format("{0}", SqlData["telefone"]);
                        Pessoa.celular = String.Format("{0}", SqlData["celular"]);
                        Pessoa.permissao = (int)SqlData["permissao"];
                        Pessoa.status = (int)SqlData["status"];

                        pessoas.Add(Pessoa);
                    }
                }

                return pessoas;
            }
        }

        public Pessoa ProcurarPessoasApartirEmailSenha(string email , string senha)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();

                comando.CommandText = "SELECT id, nome, id_condominio, permissao, status " +
                                        "FROM pessoas " +
                                        "WHERE status <> 3 " +
                                        "AND email = @email " +
                                        "AND senha = @senha;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("email", email);
                comando.Parameters.AddWithValue("senha", senha);

                Pessoa pessoas = new Pessoa();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        pessoas.id = Guid.Parse(SqlData.GetString(0));
                        pessoas.nome = String.Format("{0}", SqlData["nome"]);
                        pessoas.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                        pessoas.permissao = (int)SqlData["permissao"];
                        pessoas.status = (int)SqlData["status"];
                    }
                    else
                    {
                        return null;
                    }
                }

                return pessoas;
            }
        }
    }
}




        
