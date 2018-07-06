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
                comando.CommandText = "INSERT INTO reunioes (id, data, titulo, id_pessoa, data_atz, id_condominio) " +
                                         " values(@id, @data, @titulo, @id_pessoa, @data_atz, @id_condominio)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Reunioes.id.ToString());
                comando.Parameters.AddWithValue("data", Reunioes.data);
                comando.Parameters.AddWithValue("titulo", Reunioes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Reunioes.id_pessoa);
                comando.Parameters.AddWithValue("data_atz", Reunioes.data_atz);
                comando.Parameters.AddWithValue("id_condominio", Reunioes.id_condominio);

                comando.ExecuteNonQuery();
            }
        }

        public bool Alterar(Reunioes Reunioes)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE reunioes " +
                                        "SET data = @data," +
                                          "titulo = @titulo," +
                                       "id_pessoa = @id_pessoa," +
                                        "data_atz = @data_atz, " +
                                   "id_condominio = @id_condominio " +
                                        "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Reunioes.id.ToString());
                comando.Parameters.AddWithValue("data", Reunioes.data);
                comando.Parameters.AddWithValue("titulo", Reunioes.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Reunioes.id_pessoa);
                comando.Parameters.AddWithValue("data_atz", Reunioes.data_atz);
                comando.Parameters.AddWithValue("id_condominio", Reunioes.id_condominio);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM reunioes " +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Reunioes Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM reunioes " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Reunioes Reunioes = new Reunioes();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Reunioes.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Reunioes.data = (DateTime)SqlData["data"];
                        Reunioes.titulo = String.Format("{0}", SqlData["titulo"]);
                        Reunioes.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Reunioes.data_atz = (DateTime)SqlData["data_atz"];
                        Reunioes.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
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
                comando.CommandText = "SELECT * FROM reunioes " +
                                              "WHERE id_condominio = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Reunioes> ListReunioes = new List<Reunioes>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Reunioes Reunioes = new Reunioes();

                        Reunioes.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Reunioes.data = (DateTime)SqlData["data"];
                        Reunioes.titulo = String.Format("{0}", SqlData["titulo"]);
                        Reunioes.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Reunioes.data_atz = (DateTime)SqlData["data_atz"];
                        Reunioes.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));

                        ListReunioes.Add(Reunioes);
                    }
                }

                return ListReunioes;
            }
        }
    }
}
