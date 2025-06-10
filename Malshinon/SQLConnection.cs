using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Models
{
    public class SQLConnection
    {
        static string connectionString = "Server=localhost;DataBase=malshinon;User=root;Password='';Port=3306;";
        public MySqlConnection connection;

        
        public MySqlConnection GetConnecet()
        {
            var conn = new MySqlConnection(connectionString);
            connection = conn;
            try
            {
                connection.Open();
                //Console.WriteLine("Connected to MySQL database successfully");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Error connecting to MySQL database: {e.Message}");
            }

            return connection;
        }

        public void CloseConnecte()
        {
            try
            {
                connection.Close();
                //Console.WriteLine("close connected to database successfully");
            }

            catch(MySqlException e) 
            {
                Console.WriteLine($"Error: close connect to database is faild: {e.Message}");
            }
        }

    }
}

