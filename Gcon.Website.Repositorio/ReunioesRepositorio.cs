using System;
using System.Collections.Generic;
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
                comando.CommandText = "INSERT INTO reunioes (id, data, titulo, id_pessoa, data_atz") " +
                                         " values(@id, @data, @titulo, @id_pessoa, @data_atz)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Reunioes.id.ToString());
                comando.Parameters.AddWithValue("data", Reunioes.data);
                comando.Parameters.AddWithValue("titulo", Reunioes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Reunioes.id_pessoa);
                comando.Parameters.AddWithValue("data_atz", Reunioes.data_atz);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Reunioes Reunioes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE reunioes " +
                                        "SET data = @data," +
                                          "titulo = @titulo," +
                                       "id_pessoa = @id_pessoa," +
                                        "data_atz = @data_atz " +
                                        "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Reunioes.id.ToString());
                comando.Parameters.AddWithValue("data", Reunioes.data);
                comando.Parameters.AddWithValue("titulo", Reunioes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Reunioes.id_pessoa);
                comando.Parameters.AddWithValue("data_atz", Reunioes.data_atz);

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

        public List<Reunioes> ProcurarTodasReunioesDeUmCondominio(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "REUNIOES", "ID_REUNIOES");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                List<Reunioes> ListReunioes = new List<Reunioes>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Reunioes Reunioes = new Reunioes();

                        Reunioes.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Reunioes.DATA = (DateTime)SqlData["DATA"];
                        Reunioes.TITULO = String.Format("{0}", SqlData["TITULO"]);
                        Reunioes.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
                        Reunioes.DATA_ATZ = (DateTime)SqlData["DATA_ATZ"];

                        ListReunioes.Add(Reunioes);
                    }
                }

                return ListReunioes;
            }
        }
    }
}
