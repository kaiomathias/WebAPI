using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DBModel
    {

        public static void Insert(UsuarioModel usuario, string sql)
        {
            using (MySqlConnection conn = new MySqlConnection("Database=restwebapi;Port=3306;Data Source=127.0.0.1;User Id=root;Password=123"))
            {
                try
                {
                    Console.WriteLine("Opened!");
                   
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID", usuario.Codigo);
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@LOGIN", usuario.Login);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            Console.WriteLine("Registro incluido com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot open Connection");
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void Update(string sql)
        {

        }

        public void Delete(string sql)
        {

        }

        public void SelectAll(string sql)
        {

        }

        public void Select(string sql)
        {

        }
    }
}