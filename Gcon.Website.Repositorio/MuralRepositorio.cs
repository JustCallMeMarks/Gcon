using System;
using System.Collections.Generic;
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
                comando.CommandText = "INSERT INTO mural (id, texto, data, titulo, id_pessoa, id_condominio) " +
                                                 " VALUES(@id, @texto, @data, @titulo, @id_pessoa, @id_condominio);";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Mural.id.ToString());
                comando.Parameters.AddWithValue("texto", Mural.texto);
                comando.Parameters.AddWithValue("data", Mural.data);
                comando.Parameters.AddWithValue("titulo", Mural.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Mural.id_pessoa);
                comando.Parameters.AddWithValue("id_condominio", Mural.id_condominio);

                comando.ExecuteNonQuery();
            }
        }

        public bool Alterar(Mural Mural)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE mural " +
                                         "SET texto = @texto," +
                                              "data = @data," +
                                           "titulo  = @titulo," +
                                         "id_pessoa = @id_pessoa, " +
                                     "id_condominio = @id_condominio "+
                                          "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Mural.id.ToString());
                comando.Parameters.AddWithValue("texto", Mural.texto);
                comando.Parameters.AddWithValue("data", Mural.data);
                comando.Parameters.AddWithValue("titulo", Mural.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Mural.id_pessoa);
                comando.Parameters.AddWithValue("id_condominio", Mural.id_condominio);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM mural " +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Mural Procurar(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM mural " +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Mural Mural = new Mural();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Mural.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Mural.texto = String.Format("{0}", SqlData["texto"]);
                        Mural.data = (DateTime)SqlData["data"];
                        Mural.titulo = String.Format("{0}", SqlData["titulo"]);
                        Mural.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Mural.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                    }
                }

                return Mural;
            }
        }

        public List<Mural> ProcurarMuralDoCondominio(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM mural " +
                                               "WHERE id_condominio = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Mural> Muralist = new List<Mural>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    while (SqlData.Read())
                    {
                        Mural Mural = new Mural();

                        Mural.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Mural.texto = String.Format("{0}", SqlData["texto"]);
                        Mural.data = (DateTime)SqlData["data"];
                        Mural.titulo = String.Format("{0}", SqlData["titulo"]);
                        Mural.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Mural.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                        Muralist.Add(Mural);
                    }
                }

                return Muralist;
            }
        }
    }
}
