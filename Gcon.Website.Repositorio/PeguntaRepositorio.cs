using System;
using System.Collections.Generic;
using Gcon.Website.Dominio.Entidade.Pergunta;
using Gcon.Website.Dominio.Entidade.Resultado;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class PerguntaRepositorio : IPerguntas
    {
        string connectionString;

        public PerguntaRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Pergunta Pergunta)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "INSERT INTO perguntas (id, id_votacao, pergunta, tipo, resposta) " +
                                         " VALUES(@id, @id_votacao, @pergunta, @tipo, @resposta)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pergunta.id.ToString());
                comando.Parameters.AddWithValue("id_votacao", Pergunta.id_votacao);
                comando.Parameters.AddWithValue("pergunta", Pergunta.pergunta);
                comando.Parameters.AddWithValue("tipo", Pergunta.tipo);
                comando.Parameters.AddWithValue("resposta", Pergunta.resposta);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Pergunta Pergunta)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE perguntas " +
                                        "SET id_votacao = @id_votacao," +
                                              "pergunta = @pergunta," +
                                                  "tipo = @tipo," +
                                              "resposta = @resposta " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pergunta.id.ToString());
                comando.Parameters.AddWithValue("id_votacao", Pergunta.id_votacao);
                comando.Parameters.AddWithValue("pergunta", Pergunta.pergunta);
                comando.Parameters.AddWithValue("tipo", Pergunta.tipo);
                comando.Parameters.AddWithValue("resposta", Pergunta.resposta);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM perguntas " +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Pergunta Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM perguntas " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Pergunta Pergunta = new Pergunta();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Pergunta.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Pergunta.id_votacao = Guid.Parse(String.Format("{0}", SqlData["id_votacao"]));
                        Pergunta.pergunta = String.Format("{0}", SqlData["pergunta"]);
                        Pergunta.tipo = String.Format("{0}", SqlData["tipo"]);
                        Pergunta.resposta = new List<string>();
                        Pergunta.resposta.AddRange((string[])SqlData["resposta"]);
                    }
                }

                return Pergunta;
            }
        }

        public List<Resultado> ContarVotosPergunta(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT   resposta," +
                                      "COUNT(resposta) AS votos " +
                                      "FROM votos " +
                                      "WHERE votos.id_pergunta = @id " +
                                      "GROUP BY resposta " +
                                      "ORDER BY COUNT(resposta) DESC;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Resultado> resultados = new List<Resultado>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Resultado resultado = new Resultado();
                        resultado.resposta = String.Format("{0}", SqlData["resposta"]);
                        resultado.votos = (Int32)(Int64) SqlData["votos"];
                        resultados.Add(resultado);
                    }
                }

                return resultados;
            }
        }
    }
}
