using System;
using Gcon.Website.Dominio.Entidade.Reunioes;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class ReunioesRepositorio : IReunioes
    {
        string connectionString;

        public ReunioesRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Reunioes Reunioes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\") " +
                                         " values(@ID, @DATA, @TITULO, @ID_PESSOA, @DATA_ATZ)", "REUNIOES", "ID", "DATA", "TITULO", "ID_PESSOA", "DATA_ATZ");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Reunioes.ID.ToString());
                comando.Parameters.AddWithValue("DATA", Reunioes.DATA);
                comando.Parameters.AddWithValue("TITULO", Reunioes.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Reunioes.ID_PESSOA);
                comando.Parameters.AddWithValue("DATA_ATZ", Reunioes.DATA_ATZ);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Reunioes Reunioes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @DATA," +
                                                        "\"{3}\" = @TITULO," +
                                                        "\"{4}\" = @ID_PESSOA," +
                                                        "\"{5}\" = @DATA_ATZ " +
                                                    "WHERE \"{1}\" = @ID;", "REUNIOES", "ID", "DATA", "TITULO", "ID_PESSOA", "DATA_ATZ");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Reunioes.ID.ToString());
                comando.Parameters.AddWithValue("DATA", Reunioes.DATA);
                comando.Parameters.AddWithValue("TITULO", Reunioes.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Reunioes.ID_PESSOA);
                comando.Parameters.AddWithValue("DATA_ATZ", Reunioes.DATA_ATZ);

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
                                                           "WHERE \"{1}\" = @ID;", "REUNIOES", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Reunioes Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "REUNIOES", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Reunioes Reunioes = new Reunioes();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Reunioes.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Reunioes.DATA = (DateTime)SqlData["DATA"];
                        Reunioes.TITULO = String.Format("{0}", SqlData["TITULO"]);
                        Reunioes.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
                        Reunioes.DATA_ATZ = (DateTime)SqlData["DATA_ATZ"];
                    }
                }

                return Reunioes;
            }
        }
    }
}
