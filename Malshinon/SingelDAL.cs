using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon.Models
{
    public class SingelDAL(SQLConnection SqlConnection)
    {

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

            catch (MySqlException e)
            {
                Console.WriteLine($"Reporter added faild {e.Message}");
            }
        }

        public void DeleteBySecretCode()
        {
            try
            {
                Console.WriteLine("To delete person enter thet secret code");
                string secretCode = Console.ReadLine();
                var conn = SqlConnection.GetConnecet();
                string query = $"DELETE FROM people WHERE people.secretCode = '{secretCode}' ";
                var SqlCommend = new MySqlCommand(query, conn);
                var reader = SqlCommend.ExecuteReader();
                if (reader != null)
                {
                    Console.WriteLine("You are delete person");
                    SqlConnection.CloseConnecte();
                }
                else
                {
                    SqlConnection.CloseConnecte();
                    Console.WriteLine("Person deletion process failed");
                }
            }
            catch (MySqlException e)
            {
                SqlConnection.CloseConnecte();
                Console.WriteLine(e);
            }

        }


        
        public void Updateperson()
        {
            Console.WriteLine("To update first name presse 1");
            Console.WriteLine("To update lest name presse 2");
            Console.WriteLine("To update type presse 3");
            int chose = int.Parse(Console.ReadLine());
            string query = null;
            switch (chose)
            {
                case 1:
                    Console.WriteLine("enter old first name");
                    string OFN = Console.ReadLine();
                    Console.WriteLine("enter new first name");
                    string NFN = Console.ReadLine();
                    query = $"UPDATE people SET people.firstName = '{NFN}' WHERE people.firstName = '{OFN}' ";
                    Console.WriteLine("First name updated");
                    break;
                case 2:
                    Console.WriteLine("enter old lest name");
                    string OLN = Console.ReadLine();
                    Console.WriteLine("enter new lest name");
                    string NLN = Console.ReadLine();
                    query = $"UPDATE people SET people.lestName = '{NLN}' WHERE people.lestName = '{OLN}' ";
                    Console.WriteLine("Lest name updated");
                    break;
                case 3:
                    Console.WriteLine("enter your secret code");
                    string SC = Console.ReadLine();
                    Console.WriteLine("enter old type");
                    string OT = Console.ReadLine();
                    Console.WriteLine("enter new type");
                    string NT = Console.ReadLine();
                    query = $"UPDATE people SET people.type = '{NT}' WHERE people.secretCode = '{SC}' AND people.type = '{OT}' ";
                    Console.WriteLine("Type updated");
                    break;
            }
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            People people = null;
            while (reader.Read())
            {
                string FirsName = reader.GetString("FirsName");
                string LestName = reader.GetString("LestName");
                string SecretCode = reader.GetString("SecretCode");
                string Type = reader.GetString("Type");
                people = new People(FirsName, LestName, SecretCode, Type);
            }
            SqlConnection.CloseConnecte();
            return people;
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


        public People GetPersonBySecretCode()
        {
            var conn = SqlConnection.GetConnecet();
            People people = null;
            Console.WriteLine("enter secret code");
            string secretCode = Console.ReadLine();
            string query = $"SELECT * FROM people p WHERE secretCode = '{secretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();


        }

        public People PersonIdentification(string secretCode)
        {
            var conn = SqlConnection.GetConnecet();
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
                    }
                    SqlConnection.CloseConnecte();
                    Console.WriteLine("Identification was successful.");
                }
                else
                {
                    conn = SqlConnection.GetConnecet();
                    Console.WriteLine("enter first name");
                    string fn = Console.ReadLine();
                    Console.WriteLine("enter lest name");
                    string ln = Console.ReadLine();
                    people = new People(fn, ln, secretCode, "reporter");
                    Console.WriteLine($"codeName {secretCode} does not exist. Creates a new record.");
                    AddReporter(people);
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
            return people;
        }


        public IntelReports InsertIntelReport()
        {
            IntelReports Report = null;
            try
            {
                var conn = SqlConnection.GetConnecet();
                Console.WriteLine("To report enter your name code");
                string codeName = Console.ReadLine();
                string query = @"INSERT INTO intelreports
                                (ReporterId, TargatId, Text) 
                                VALUES(@ReporterId, @TargatId, @Text)";
                var SqlCommend = new MySqlCommand(query, conn);
                SqlCommend.Parameters.AddWithValue("@ReporterId", Report.ReporterId);
                SqlCommend.Parameters.AddWithValue("@TargatId", Report.TargatId);
                SqlCommend.Parameters.AddWithValue("@Text", Report.Text);
                var reader = SqlCommend.ExecuteReader();
                SqlConnection.CloseConnecte();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Report;
        }

        public void UpdateReportCounts()
        {
            People people = GetPersonBySecretCode();
            var conn = SqlConnection.GetConnecet();
            string query = $"UPDATE people SET numReports = numReports + 1 WHERE secretCode = '{people.SecretCode}' ";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            if (people.NumReports >= 10)
            {
                UpdateTypeBySecretCode();
                Console.WriteLine("Type changed to potential Agent");
            }
            SqlConnection.CloseConnecte();

        }

        public void UpdateTypeBySecretCode()
        {
            var conn = SqlConnection.GetConnecet();
            People people = null;
            Console.WriteLine("enter secret code");
            string secretCode = Console.ReadLine();
            string query = $"UPDATE people SET type = 'potentialAgent' WHERE secretCode = '{secretCode}'";
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            while (reader.Read())
            {
                string Type = reader.GetString("Type");
            }
            SqlConnection.CloseConnecte();
        }

        //public void UpdateMentionCounts()
        //{
        //    var conn = SqlConnection.GetConnecet();
        //    Console.WriteLine("enter secret code");
        //    string secretCode = Console.ReadLine();
        //    string query = $"UPDATE people SET NumMentions = NumMentions + 1 WHERE id = {secretCode}";
        //    var SqlCommend = new MySqlCommand(query, conn);
        //    var reader = SqlCommend.ExecuteReader();
        //    SqlConnection.CloseConnecte();
        //}todo

        //public void AddNewReport()
        //{
        //    People reporter = GetPersonBySecretCode();
        //    IntelReports report = InsertIntelReport();
        //    string[] words = report.Text.Split(' ');
        //    List<string> textList = new List<string>(words);
        //}todo


    }
}
