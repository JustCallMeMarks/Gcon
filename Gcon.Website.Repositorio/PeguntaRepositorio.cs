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
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\") " +
                                         " values(@ID, @ID_VOTACAO, @PERGUNTA, @TIPO)", "PERGUNTAS", "ID", "ID_VOTACAO", "PERGUNTA", "TIPO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Pergunta.ID.ToString());
                comando.Parameters.AddWithValue("ID_VOTACAO", Pergunta.ID_VOTACAO);
                comando.Parameters.AddWithValue("PERGUNTA", Pergunta.PERGUNTA);
                comando.Parameters.AddWithValue("TIPO", Pergunta.TIPO);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Pergunta Pergunta)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @ID_VOTACAO," +
                                                        "\"{3}\" = @PERGUNTA," +
                                                        "\"{4}\" = @TIPO " +
                                                    "WHERE \"{1}\" = @ID;", "PERGUNTAS", "ID", "ID_VOTACAO", "PERGUNTA", "TIPO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Pergunta.ID.ToString());
                comando.Parameters.AddWithValue("ID_VOTACAO", Pergunta.ID_VOTACAO);
                comando.Parameters.AddWithValue("PERGUNTA", Pergunta.PERGUNTA);
                comando.Parameters.AddWithValue("TIPO", Pergunta.TIPO);

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
                                                           "WHERE \"{1}\" = @ID;", "PERGUNTAS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Pergunta Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "PERGUNTAS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Pergunta Pergunta = new Pergunta();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Pergunta.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Pergunta.ID_VOTACAO = Guid.Parse(String.Format("{0}", SqlData["ID_VOTACAO"]));
                        Pergunta.PERGUNTA = String.Format("{0}", SqlData["PERGUNTA"]);
                        Pergunta.TIPO = String.Format("{0}", SqlData["TIPO"]);
                    }
                }

                return Pergunta;
            }
        }
    }
}
