using System;
using Gcon.Website.Dominio.Entidade.Mural;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class MuralRepositorio : IMural
    {
        string connectionString;

        public MuralRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Mural Mural)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\") " +
                                         " values(@ID, @TEXTO, @DATA, @TITULO, @ID_PESSOA)", "MURAL", "ID", "TEXTO", "DATA", "TITULO", "ID_PESSOA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Mural.ID.ToString());
                comando.Parameters.AddWithValue("TEXTO", Mural.TEXTO);
                comando.Parameters.AddWithValue("DATA", Mural.DATA);
                comando.Parameters.AddWithValue("TITULO", Mural.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Mural.ID_PESSOA);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Mural Mural)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @TEXTO," +
                                                        "\"{3}\" = @DATA," +
                                                        "\"{4}\" = @TITULO," +
                                                        "\"{5}\" = @ID_PESSOA " +
                                                    "WHERE \"{1}\" = @ID;", "MURAL", "ID", "TEXTO", "DATA", "TITULO", "ID_PESSOA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Mural.ID.ToString());
                comando.Parameters.AddWithValue("TEXTO", Mural.TEXTO);
                comando.Parameters.AddWithValue("DATA", Mural.DATA);
                comando.Parameters.AddWithValue("TITULO", Mural.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Mural.ID_PESSOA);

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
                                                           "WHERE \"{1}\" = @ID;", "MURAL", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Mural Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "MURAL", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Mural Mural = new Mural();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Mural.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Mural.TEXTO = String.Format("{0}", SqlData["TEXTO"]);
                        Mural.DATA = (DateTime)SqlData["DATA"];
                        Mural.TITULO = String.Format("{0}", SqlData["TITULO"]);
                        Mural.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
                    }
                }

                return Mural;
            }
        }
    }
}
