using System;
using System.Collections.Generic;
using Gcon.Website.Dominio.Entidade.Atas;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class AtasRepositorio : IAtas
    {
        string connectionString;

        public AtasRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Atas Atas)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "INSERT INTO atas (id, texto, data, titulo, id_pessoa, id_condominio) " +
                                                " VALUES(@id, @texto, @data, @titulo, @id_pessoa, @id_condominio)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Atas.id.ToString());
                comando.Parameters.AddWithValue("texto", Atas.texto);
                comando.Parameters.AddWithValue("data", Atas.data);
                comando.Parameters.AddWithValue("titulo", Atas.titulo);
                comando.Parameters.AddWithValue("id_pessoa", Atas.id_pessoa);
                comando.Parameters.AddWithValue("id_condominio", Atas.id_condominio);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Atas Atas)
        {
              using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
              {
                  conexao.Open();
                  NpgsqlCommand comando = new NpgsqlCommand();
                  comando.CommandText = "UPDATE atas" +
                                           "SET texto          = @texto," +
                                                "data          = @data," +
                                                "titulo        = @titulo," +
                                                "id_pessoa     = @id_pessoa," +
                                                "id_condominio = @id_condominio" +
                                         "WHERE id = @id;";

                  comando.Connection = conexao;

                  comando.Parameters.AddWithValue("id", Atas.id.ToString());
                  comando.Parameters.AddWithValue("texto", Atas.texto);
                  comando.Parameters.AddWithValue("data", Atas.data);
                  comando.Parameters.AddWithValue("titulo", Atas.titulo);
                  comando.Parameters.AddWithValue("id_pessoa", Atas.id_pessoa);
                  comando.Parameters.AddWithValue("id_condominio", Atas.id_condominio);

                  comando.ExecuteNonQuery();
              }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM atas" +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Atas Procurar(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                 conexao.Open();
                 NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM atas" +
                                              "WHERE id = @id;";

                 comando.Connection = conexao;

                 comando.Parameters.AddWithValue("id", id.ToString());

                Atas Atas = new Atas();

                 using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                 {
                     if (SqlData.Read())
                     {
                         Atas.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                         Atas.texto = String.Format("{0}", SqlData["texto"]);
                         Atas.data = (DateTime) SqlData["data"];
                         Atas.titulo = String.Format("{0}", SqlData["titulo"]);
                         Atas.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                         Atas.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));
                    }
                 }

                 return Atas;
             }
        }

        public List<Atas> ProcurarTodasAtasDeUmCondominio(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "SELECT * FROM atas" +
                                              "WHERE id_condominio = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                List<Atas> TodasAtas = new List<Atas>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {

                    while (SqlData.Read())
                    {
                        Atas Atas = new Atas();

                        Atas.id = Guid.Parse(String.Format("{0}", SqlData["id"]));
                        Atas.texto = String.Format("{0}", SqlData["texto"]);
                        Atas.data = (DateTime)SqlData["data"];
                        Atas.titulo = String.Format("{0}", SqlData["titulo"]);
                        Atas.id_pessoa = Guid.Parse(String.Format("{0}", SqlData["id_pessoa"]));
                        Atas.id_condominio = Guid.Parse(String.Format("{0}", SqlData["id_condominio"]));

                        TodasAtas.Add(Atas);
                    }
                }

                return TodasAtas;
            }
        }
    }
}
