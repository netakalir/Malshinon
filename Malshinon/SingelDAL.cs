using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Models
{
    public class SingelDAL
    {
        public SQLConnection SqlConnection = new SQLConnection();
        public void AddReporter(People people) 
        {
            try
            {
                var conn = SqlConnection.GetConnecet();
                string query = @"INSERT INTO people 
                (firstName, lestName, secretCode, type, numReports, numMentions) 
                VALUES(@firstName, @lestName, @secretCode, @type, @numReports, @numMentions)";
                var SqlCommend = new MySqlCommand(query, conn);
                SqlCommend.Parameters.AddWithValue("@firstName", people.FirsName);
                SqlCommend.Parameters.AddWithValue("@lestName", people.LestName);
                SqlCommend.Parameters.AddWithValue("@secretCode", people.SecretCode);
                SqlCommend.Parameters.AddWithValue("@type", people.Type);
                SqlCommend.Parameters.AddWithValue("@numReports", people.NumReports);
                SqlCommend.Parameters.AddWithValue("@numMentions", people.NumMentions);
                var reader = SqlCommend.ExecuteReader();
                SqlConnection.CloseConnecte();
                Console.WriteLine("Reporter added successfully");
            }

            catch(MySqlException e) 
            {
                Console.WriteLine($"Reporter added faild {e.Message}");
            }
        }

        public void AddTargater(People people)
        {
            try
            {
                var conn = SqlConnection.GetConnecet();
                string query = @"INSERT INTO people 
                (firstName, lestName, secretCode, type, numReports, numMentions) 
                VALUES(@firstName, @lestName, @secretCode, @type, @numReports, @numMentions)";
                var SqlCommend = new MySqlCommand(query, conn);
                SqlCommend.Parameters.AddWithValue("@firstName", people.FirsName);
                SqlCommend.Parameters.AddWithValue("@lestName", people.LestName);
                SqlCommend.Parameters.AddWithValue("@secretCode", people.SecretCode);
                SqlCommend.Parameters.AddWithValue("@type", people.Type);
                SqlCommend.Parameters.AddWithValue("@numReports", people.NumReports);
                SqlCommend.Parameters.AddWithValue("@numMentions", people.NumMentions);
                var reader = SqlCommend.ExecuteReader();
                SqlConnection.CloseConnecte();
                Console.WriteLine("Targater added successfully");
            }

            catch (MySqlException e)
            {
                Console.WriteLine($"Targater added faild {e.Message}");
            }
        }

    }
}
