using System;
using Gcon.Website.Dominio.Entidade.Condominio;
using Gcon.Website.Dominio.Interface;
using Npgsql;

namespace Gcon.Website.Repositorio
{
    public class CondominioRepositorio : ICondominioRepositorio
    {
        string connectionString;

        public CondominioRepositorio(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Condominio Condominio)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            { 
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("insert into \"{0}\" (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\") " +
                                         " values(@ID, @QTD_AP, @NOME, @RUA, @BAIRRO, @CIDADE, @ESTADO, @PAIS, @NUMERO)","CONDOMINIO", "ID", "QTD_AP", "NOME", "RUA", "BAIRRO", "CIDADE", "ESTADO", "PAIS", "NUMERO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Condominio.Id);
                comando.Parameters.AddWithValue("QTD_AP", Condominio.QTD_AP);
                comando.Parameters.AddWithValue("NOME", Condominio.NOME);
                comando.Parameters.AddWithValue("RUA", Condominio.RUA);
                comando.Parameters.AddWithValue("BAIRRO", Condominio.BAIRRO);
                comando.Parameters.AddWithValue("CIDADE", Condominio.CIDADE);
                comando.Parameters.AddWithValue("ESTADO", Condominio.ESTADO);
                comando.Parameters.AddWithValue("PAIS", Condominio.PAIS);
                comando.Parameters.AddWithValue("NUMERO", Condominio.NUMERO);

                comando.ExecuteNonQuery();

            }
        }

        public void Alterar(Condominio Condominio)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("UPDATE \"{0}\" " +
                                                    "SET \"{2}\" = @QTD_AP,"+
                                                        "\"{3}\" = @NOME,"+
                                                        "\"{4}\" = @RUA,"+
                                                        "\"{5}\" = @BAIRRO,"+
                                                        "\"{6}\" = @CIDADE,"+
                                                        "\"{7}\" = @ESTADO,"+
                                                        "\"{8}\" = @PAIS,"+
                                                        "\"{9}\" =  @NUMERO "+
                                                    "WHERE \"{1}\" = @ID;", "CONDOMINIO", "ID", "QTD_AP", "NOME", "RUA", "BAIRRO", "CIDADE", "ESTADO", "PAIS", "NUMERO");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", Condominio.Id.ToString());
                comando.Parameters.AddWithValue("QTD_AP", Condominio.QTD_AP);
                comando.Parameters.AddWithValue("NOME", Condominio.NOME);
                comando.Parameters.AddWithValue("RUA", Condominio.RUA);
                comando.Parameters.AddWithValue("BAIRRO", Condominio.BAIRRO);
                comando.Parameters.AddWithValue("CIDADE", Condominio.CIDADE);
                comando.Parameters.AddWithValue("ESTADO", Condominio.ESTADO);
                comando.Parameters.AddWithValue("PAIS", Condominio.PAIS);
                comando.Parameters.AddWithValue("NUMERO", Condominio.NUMERO);

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
                                                           "WHERE \"{1}\" = @ID;", "CONDOMINIO", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                comando.ExecuteNonQuery();

             }
        }
        
        public Condominio Procurar(Guid id)
        {
             using(NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = string.Format("Select * from \"{0}\"" +
                                                            "WHERE \"{1}\" = @ID;", "CONDOMINIO", "ID");
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("ID", id.ToString());

                Condominio Condominio = new Condominio();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Condominio.Id     = Guid.Parse(String.Format("{0}",SqlData["ID"]));
                        Condominio.NOME   = String.Format("{0}", SqlData["NOME"]);
                        Condominio.PAIS   = String.Format("{0}", SqlData["PAIS"]);
                        Condominio.RUA    = String.Format("{0}", SqlData["RUA"]);
                        Condominio.BAIRRO = String.Format("{0}", SqlData["BAIRRO"]);
                        Condominio.CIDADE = String.Format("{0}", SqlData["CIDADE"]);
                        Condominio.ESTADO = String.Format("{0}", SqlData["ESTADO"]);
                        Condominio.QTD_AP = (int)SqlData["QTD_AP"];
                        Condominio.NUMERO = (int) SqlData["NUMERO"];
                    }
                }
               
                return Condominio;
             }
        }
    }
}
