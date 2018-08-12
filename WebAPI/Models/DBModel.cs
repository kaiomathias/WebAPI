using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DBModel
    {
       private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();



        public static void Insert(UsuarioModel usuario, string sql)
        {
            using (MySqlConnection conn = new MySqlConnection("Database=restwebapi;Port=3306;Data Source=127.0.0.1;User Id=root;Password=123"))
            {
                try
                {
                    logger.Info("Opened!");
                   
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
                            logger.Info("Registro incluido com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Erro: " + ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
                catch (Exception e)
                {
                    logger.Error(e, "Cannot open Connection");
                }
            }
        }

        public static void Update(UsuarioModel usuario, string sql)
        {

        }

        public static void Delete(UsuarioModel usuario, string sql)
        {
            using (MySqlConnection conn = new MySqlConnection("Database=restwebapi;Port=3306;Data Source=127.0.0.1;User Id=root;Password=123"))
            {
                try
                {
                    

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID", usuario.Codigo);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conn.Open();
                    logger.Info("Opened!");

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            logger.Info("Deleted!");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Erro: " + ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
                catch (Exception e)
                {
                    logger.Error(e, "Cannot open Connection");
                }
            }
        }

        public static void SelectAll(UsuarioModel usuario, string sql)
        {

        }

        public static void Select(UsuarioModel usuario, string sql)
        {

        }
    }
}