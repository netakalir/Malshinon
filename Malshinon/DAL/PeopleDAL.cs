using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Malshinon.Models;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.DAL
{
    public class PeopleDAL(SQLConnection sqlConn)
    {
        public void InsertNewPerson(People people) 
        {
            try
            {
                var conn = sqlConn.GetConnecet();
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
                sqlConn.CloseConnecte();
                Console.WriteLine("person added successfully");

            }

            catch (MySqlException e)
            {
                Console.WriteLine($"person added faild {e.Message}");
            }
        }

        public bool PersonIdentification(string secretCode)
        {
            bool status = false;
            var conn = sqlConn.GetConnecet();
            string query = $"SELECT * FROM people p WHERE secretCode = '{secretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            People people = null;
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string firstName = reader.GetString("firstName");
                        string lestName = reader.GetString("lestName");
                        string Code = reader.GetString("secretCode");
                        string type = reader.GetString("type");
                        int NumReports = reader.GetInt32("NumReports");
                        int NumMentions = reader.GetInt32("NumMentions");
                        people = new(firstName, lestName, Code, type, NumReports, NumMentions);
                        status = true;
                    }
                    sqlConn.CloseConnecte();
                    
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return status;
        }

        //public void AddTargater(string secratCode)
        //{
        //    try
        //    {
        //        People people = null;
        //        var conn = sqlConn.GetConnecet();
        //        string query = @"INSERT INTO people 
        //        (firstName, lestName, secretCode, type, numReports, numMentions) 
        //        VALUES(@firstName, @lestName, @secretCode, @type, @numReports, @numMentions)";
        //        var SqlCommend = new MySqlCommand(query, conn);
        //        SqlCommend.Parameters.AddWithValue("@firstName", people.FirsName);
        //        SqlCommend.Parameters.AddWithValue("@lestName", people.LestName);
        //        SqlCommend.Parameters.AddWithValue("@secretCode", people.SecretCode);
        //        SqlCommend.Parameters.AddWithValue("@type", people.Type);
        //        SqlCommend.Parameters.AddWithValue("@numReports", people.NumReports);
        //        SqlCommend.Parameters.AddWithValue("@numMentions", people.NumMentions);
        //        var reader = SqlCommend.ExecuteReader();
        //        sqlConn.CloseConnecte();
        //        Console.WriteLine("Targater added successfully");
        //    }

        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine($"Targater added faild {e.Message}");
        //    }
        //}

        public void DeleteBySecretCode(string secretCode)
        {
            try
            {
                var conn = sqlConn.GetConnecet();
                string query = $"DELETE FROM people WHERE people.secretCode = '{secretCode}' ";
                var SqlCommend = new MySqlCommand(query, conn);
                var reader = SqlCommend.ExecuteReader();
                if (reader != null)
                {
                    Console.WriteLine("You are delete person");
                    sqlConn.CloseConnecte();
                }
                else
                {
                    sqlConn.CloseConnecte();
                    Console.WriteLine("Person deletion process failed");
                }
            }
            catch (MySqlException e)
            {
                sqlConn.CloseConnecte();
                Console.WriteLine(e);
            }
        }

        public People GetPersonBySecretCode(string secretCode)
        {
            var conn = sqlConn.GetConnecet();
            People people = null;
            string query = $"SELECT * FROM people p WHERE secretCode = '{secretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string firstName = reader.GetString("firstName");
                        string lestName = reader.GetString("lestName");
                        string Code = reader.GetString("secretCode");
                        string type = reader.GetString("type");
                        int NumReports = reader.GetInt32("NumReports");
                        int NumMentions = reader.GetInt32("NumMentions");
                        people = new(firstName, lestName, Code, type, NumReports, NumMentions);
                    }
                    sqlConn.CloseConnecte();
                    return people;
                }
                else
                {
                    Console.WriteLine($"codeName {secretCode} does not exist. Creates a new record.");
                    Thread.Sleep(3000);
                    Console.WriteLine("enter first name");
                    string fn = Console.ReadLine();
                    Console.WriteLine("enter lest name");
                    string ln = Console.ReadLine();
                    Console.WriteLine("enter your type");
                    string type = Console.ReadLine();
                    people = new(fn, ln, secretCode, type);
                    InsertNewPerson(people);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return null;
        }

        public void Updateperson(string secretCode)
        {
            var conn = sqlConn.GetConnecet();
            Console.WriteLine("To update first name presse 1");
            Console.WriteLine("To update lest name presse 2");
            int chose = int.Parse(Console.ReadLine());
            string query = null;
            switch (chose)
            {
                case 1:
                    Console.WriteLine("enter new first name");
                    string NFN = Console.ReadLine();
                    query = $"UPDATE people SET people.firstName = '{NFN}' WHERE people.secretCode = '{secretCode}' ";
                    Console.WriteLine("First name updated");
                    break;
                case 2:
                    Console.WriteLine("enter new lest name");
                    string NLN = Console.ReadLine();
                    query = $"UPDATE people SET people.lestName = '{NLN}' WHERE people.secretCode = '{secretCode}' ";
                    Console.WriteLine("Lest name updated");
                    break;
            }
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            sqlConn.CloseConnecte();
        }

        public void UpdateReportCounts(string secretCode)
        {
            People people = GetPersonBySecretCode(secretCode);
            var conn = sqlConn.GetConnecet();
            string query = $"UPDATE people SET numReports = numReports + 1 WHERE secretCode = '{secretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            if (people.NumReports >= 10)
            {
                UpdateTypeBySecretCode(secretCode);
                Console.WriteLine("Type changed to potential Agent");
            }
            sqlConn.CloseConnecte();

        }

        public void UpdateMentionCounts(string secretCode)
        {
            var conn = sqlConn.GetConnecet();
            string query = $"UPDATE people SET people.NumMentions = NumMentions + 1 WHERE prople.secretCode = '{secretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            sqlConn.CloseConnecte();
        }
        
        private void UpdateTypeBySecretCode(string secretCode)
        {
            var conn = sqlConn.GetConnecet();
            People people = null;
            string query = $"UPDATE people SET people.type = 'potentialAgent' WHERE secretCode = '{secretCode}'";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            sqlConn.CloseConnecte();
        }

        //public People GetRecordOfPeople()
        //{
        //    return people;
        //}todo
    }
}
