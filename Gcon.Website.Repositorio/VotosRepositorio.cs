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
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\") " +
                                         " values(@ID, @ID_PESSOA, @ID_PERGUNTA, @RESPOSTA)", "VOTOS", "ID", "ID_PESSOA", "ID_PERGUNTA", "RESPOSTA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Votos.ID.ToString());
                comando.Parameters.AddWithValue("ID_PESSOA", Votos.ID_PESSOA);
                comando.Parameters.AddWithValue("ID_PERGUNTA", Votos.ID_PERGUNTA);
                comando.Parameters.AddWithValue("RESPOSTA", Votos.RESPOSTA);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Votos Votos)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @ID_PESSOA," +
                                                        "\"{3}\" = @ID_PERGUNTA," +
                                                        "\"{4}\" = @RESPOSTA " +
                                                    "WHERE \"{1}\" = @ID;", "VOTOS", "ID", "ID_PESSOA", "ID_PERGUNTA", "RESPOSTA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Votos.ID.ToString());
                comando.Parameters.AddWithValue("ID_PESSOA", Votos.ID_PESSOA);
                comando.Parameters.AddWithValue("ID_PERGUNTA", Votos.ID_PERGUNTA);
                comando.Parameters.AddWithValue("RESPOSTA", Votos.RESPOSTA);

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
                                                           "WHERE \"{1}\" = @ID;", "VOTOS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Votos Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "VOTOS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Votos Votos = new Votos();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Votos.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Votos.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
                        Votos.ID_PERGUNTA = Guid.Parse(String.Format("{0}", SqlData["ID_PERGUNTA"]));
                        Votos.RESPOSTA = String.Format("{0}", SqlData["RESPOSTA"]);
                    }
                }

                return Votos;
            }
        }
    }
}
