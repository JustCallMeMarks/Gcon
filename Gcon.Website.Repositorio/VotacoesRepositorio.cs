using System;
using Gcon.Website.Dominio.Entidade.Votacoes;
using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Dominio.Interface;
using Npgsql;
using System.Collections.Generic;

namespace Gcon.Website.Repositorio
{
    public class VotacoesRepositorio : IVotacoes
    {
        string connectionString;

        public VotacoesRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Votacoes Votacoes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "INSERT INTO votacoes (id, descricao, data, titulo, id_pessoa) " +
                                         " VALUES(@id, @descricao, @data, @titulo, @id_pessoa)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Votacoes.id.ToString());
                comando.Parameters.AddWithValue("descricao", Votacoes.descricao);
                comando.Parameters.AddWithValue("data", Votacoes.data);
                comando.Parameters.AddWithValue("titulo", Votacoes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Votacoes.id_pessoa);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Votacoes Votacoes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE votacoes " +
                                         "SET descricao = @descricao," +
                                                  "data = @data," +
                                                "titulo = @titulo," +
                                             "id_pessoa = @id_pessoa " +
                                       "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Votacoes.id.ToString());
                comando.Parameters.AddWithValue("descricao", Votacoes.descricao);
                comando.Parameters.AddWithValue("data", Votacoes.data);
                comando.Parameters.AddWithValue("titulo", Votacoes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Votacoes.id_pessoa);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM votacoes " +
                                            "WHERE id" = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Votacoes Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM votacoes " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Votacoes Votacoes = new Votacoes();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Votacoes.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Votacoes.descricao = String.Format("{0}", SqlData["descricao"]);
                        Votacoes.data = (DateTime)SqlData["data"];
                        Votacoes.titulo = String.Format("{0}", SqlData["titulo"]);
                        Votacoes.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                    }
                }

                return Votacoes;
            }
        }

        public List<Pergunta> TodasPerguntasDeUmaVotação(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("SELECT * FROM perguntas" +
                                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Pergunta> Perguntas = new List<Pergunta>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Pergunta Pergunta = new Pergunta();

                        Pergunta.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Pergunta.id_votacao = Guid.Parse(String.Format("{0}", SqlData["id_votacao"]));
                        Pergunta.pergunta = String.Format("{0}", SqlData["pergunta"]);
                        Pergunta.tipo = String.Format("{0}", SqlData["tipo"]);

                        Perguntas.Add(Pergunta);
                    }
                }

                return Perguntas;
            }
        }

        public List<Votacoes> ProcurarTodasVotacoesDeUmCondominio(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM votacoes" +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Votacoes> ListVotacoes = new List<Votacoes>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Votacoes Votacoes = new Votacoes();

                        Votacoes.ID = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Votacoes.DESCRICAO = String.Format("{0}", SqlData["descricao"]);
                        Votacoes.DATA = (DateTime)SqlData["data"];
                        Votacoes.TITULO = String.Format("{0}", SqlData["titulo"]);
                        Votacoes.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));

                        ListVotacoes.Add(Votacoes);
                    }
                }

                return ListVotacoes;
            }
        }
    }
}
