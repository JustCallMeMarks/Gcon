using System;
using Gcon.Website.Dominio.Entidade.Votos;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class VotosRepositorio : IVotos
    {
        string connectionString;

        public VotosRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Votos Votos)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "INSERT INTO votos (id, id_pessoa, id_pergunta, resposta) " +
                                         " VALUES(@id, @id_pessoa, @id_pergunta, @resposta)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Votos.id.ToString());
                comando.Parameters.AddWithValue("id_pessoa", Votos.id_pessoa);
                comando.Parameters.AddWithValue("id_pergunta", Votos.id_pergunta);
                comando.Parameters.AddWithValue("resposta", Votos.resposta);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Votos Votos)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE votos " +
                                         "SET id_pessoa = @id_pessoa," +
                                             "id_pergunta = @id_pergunta," +
                                             "resposta = @resposta " +
                                       "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Votos.id.ToString());
                comando.Parameters.AddWithValue("id_pessoa", Votos.id_pessoa);
                comando.Parameters.AddWithValue("id_pergunta", Votos.id_pergunta);
                comando.Parameters.AddWithValue("resposta", Votos.resposta);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM votos" +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Votos Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM votos" +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Votos Votos = new Votos();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Votos.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Votos.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Votos.id_pergunta = Guid.Parse(String.Format("{0}", SqlData["id_pergunta"]));
                        Votos.resposta = String.Format("{0}", SqlData["resposta"]);
                    }
                }

                return Votos;
            }
        }
    }
}
