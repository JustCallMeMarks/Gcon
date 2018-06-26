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
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\") " +
                                         " values(@ID, @TEXTO, @DATA, @TITULO, @ID_PESSOA)", "ATAS", "ID", "TEXTO", "DATA", "TITULO", "ID_PESSOA");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Atas.ID.ToString());
                comando.Parameters.AddWithValue("TEXTO", Atas.TEXTO);
                comando.Parameters.AddWithValue("DATA", Atas.DATA);
                comando.Parameters.AddWithValue("TITULO", Atas.TITULO);
                comando.Parameters.AddWithValue("ID_PESSOA", Atas.ID_PESSOA);

                comando.ExecuteNonQuery();
            }
        }

        public void Alterar(Atas Atas)
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
                                                      "WHERE \"{1}\" = @ID;", "ATAS", "ID", "TEXTO", "DATA", "TITULO", "ID_PESSOA");
                  comando.Connection = conexao;

                  comando.Parameters.AddWithValue("ID", Atas.ID.ToString());
                  comando.Parameters.AddWithValue("TEXTO", Atas.TEXTO);
                  comando.Parameters.AddWithValue("DATA", Atas.DATA);
                  comando.Parameters.AddWithValue("TITULO", Atas.TITULO);
                  comando.Parameters.AddWithValue("ID_PESSOA", Atas.ID_PESSOA);

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
                                                           "WHERE \"{1}\" = @ID;", "ATAS", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

            }
        }

        public Atas Procurar(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                 conexao.Open();
                 NpgsqlCommand comando = new NpgsqlCommand();
                 comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                             "WHERE \"{1}\" = @ID;", "ATAS", "ID");
                 comando.Connection = conexao;

                 comando.Parameters.AddWithValue("ID", id.ToString());

                Atas Atas = new Atas();

                 using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                 {
                     if (SqlData.Read())
                     {
                         Atas.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                         Atas.TEXTO = String.Format("{0}", SqlData["TEXTO"]);
                         Atas.DATA = (DateTime) SqlData["DATA"];
                         Atas.TITULO = String.Format("{0}", SqlData["TITULO"]);
                         Atas.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));
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
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                             "WHERE \"{1}\" = @ID;", "ATAS", "ID_CONDOMINIO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                List<Atas> TodasAtas = new List<Atas>();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {

                    while (SqlData.Read())
                    {
                        Atas Atas = new Atas();

                        Atas.ID = Guid.Parse(String.Format("{0}", SqlData["ID"]));
                        Atas.TEXTO = String.Format("{0}", SqlData["TEXTO"]);
                        Atas.DATA = (DateTime)SqlData["DATA"];
                        Atas.TITULO = String.Format("{0}", SqlData["TITULO"]);
                        Atas.ID_PESSOA = Guid.Parse(String.Format("{0}", SqlData["ID_PESSOA"]));

                        TodasAtas.Add(Atas);
                    }
                }

                return TodasAtas;
            }
        }
    }
}
