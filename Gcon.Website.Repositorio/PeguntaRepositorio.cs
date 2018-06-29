using System;
using Gcon.Website.Dominio.Entidade.Pergunta;
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
                comando.CommandText = "INSERT INTO perguntas (id, id_votacao, pergunta, tipo) " +
                                         " VALUES(@id, @id_votacao, @pergunta, @tipo)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pergunta.id.ToString());
                comando.Parameters.AddWithValue("id_votacao", Pergunta.id_votacao);
                comando.Parameters.AddWithValue("pergunta", Pergunta.pergunta);
                comando.Parameters.AddWithValue("tipo", Pergunta.tipo);

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
                                                  "tipo = @tipo " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Pergunta.id.ToString());
                comando.Parameters.AddWithValue("id_votacao", Pergunta.id_votacao);
                comando.Parameters.AddWithValue("pergunta", Pergunta.pergunta);
                comando.Parameters.AddWithValue("tipo", Pergunta.tipo);

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
                    }
                }

                return Pergunta;
            }
        }
    }
}
