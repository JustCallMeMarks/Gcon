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
                comando.CommandText = "INSERT INTO condomionio (id, qtd_ap, nome, rua, bairro, cidade, estado, pais, numero) " +
                                                    " VALUES(@id, @qtd_ap, @nome, @rua, @bairro, @cidade, @estado, @pais, @numero)";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Condominio.id);
                comando.Parameters.AddWithValue("qtd_ap", Condominio.qtd_ap);
                comando.Parameters.AddWithValue("nome", Condominio.nome);
                comando.Parameters.AddWithValue("rua", Condominio.rua);
                comando.Parameters.AddWithValue("bairro", Condominio.bairro);
                comando.Parameters.AddWithValue("cidade", Condominio.cidade);
                comando.Parameters.AddWithValue("estado", Condominio.estado);
                comando.Parameters.AddWithValue("pais", Condominio.pais);
                comando.Parameters.AddWithValue("numero", Condominio.numero);

                comando.ExecuteNonQuery();

            }
        }

        public void Alterar(Condominio Condominio)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
            {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "UPDATE condomionio " +
                                         "SET qtd_ap = @qtd_ap," +
                                               "nome = @nome," +
                                                "rua = @rua," +
                                             "bairro = @bairro," +
                                             "cidade = @cidade,"+
                                             "estado = @estado," +
                                               "pais = @pais," +
                                             "numero = @numero " +
                                       "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", Condominio.id);
                comando.Parameters.AddWithValue("qtd_ap", Condominio.qtd_ap);
                comando.Parameters.AddWithValue("nome", Condominio.nome);
                comando.Parameters.AddWithValue("rua", Condominio.rua);
                comando.Parameters.AddWithValue("bairro", Condominio.bairro);
                comando.Parameters.AddWithValue("cidade", Condominio.cidade);
                comando.Parameters.AddWithValue("estado", Condominio.estado);
                comando.Parameters.AddWithValue("pais", Condominio.pais);
                comando.Parameters.AddWithValue("numero", Condominio.numero);

                comando.ExecuteNonQuery();

            }
        }

        public void Excluir(Guid id)
        {
             using (NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "DELETE FROM condomionio" +
                                            "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                comando.ExecuteNonQuery();

             }
        }
        
        public Condominio Procurar(Guid id)
        {
             using(NpgsqlConnection conexao = new NpgsqlConnection(this.connectionString))
             {
                conexao.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.CommandText = "Select * from condomionio" +
                                              "WHERE id = @id;";
                comando.Connection = conexao;

                comando.Parameters.AddWithValue("id", id.ToString());

                Condominio Condominio = new Condominio();

                using (NpgsqlDataReader SqlData = comando.ExecuteReader())
                {
                    if (SqlData.Read())
                    {
                        Condominio.id     = Guid.Parse(String.Format("{0}",SqlData["id"]));
                        Condominio.nome   = String.Format("{0}", SqlData["nome"]);
                        Condominio.pais   = String.Format("{0}", SqlData["pais"]);
                        Condominio.rua    = String.Format("{0}", SqlData["rua"]);
                        Condominio.bairro = String.Format("{0}", SqlData["bairro"]);
                        Condominio.cidade = String.Format("{0}", SqlData["cidade"]);
                        Condominio.estado = String.Format("{0}", SqlData["estado"]);
                        Condominio.qtd_ap = (int)SqlData["qtd_ap"];
                        Condominio.numero = (int) SqlData["numero"];
                    }
                }
               
                return Condominio;
             }
        }
    }
}
