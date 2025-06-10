using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            var conn = SqlConnection.GetConnecet();
            var SqlCommend = new MySqlCommand(query, conn);
            var reader = SqlCommend.ExecuteReader();
            SqlConnection.CloseConnecte();
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


        //public void SubmittingAreport()
        //{
        //    Console.WriteLine("To access. enter your codeName");
        //    string codeName = Console.ReadLine();
        //    var conn = SqlConnection.GetConnecet();
        //    string query = $"SELECT p.text AS text * FROM peopel p WHERE p.codeName = {codeName} ";
        //}

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

        //public IntelReports AddReport()
        //{
        //    Console.WriteLine("To report enter your name code ");
        //    string codeName = Console.ReadLine();
        //    var conn = SqlConnection.GetConnecet();
        //    string query = $"SELECT * FROM IntelReports  WHERE target_id = '{codeName}' ";
        //    var SqlCommend = new MySqlCommand(query, conn);
        //    var reader = SqlCommend.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        Console.WriteLine("You evaint to report. fail free");
        //        string text = Console.ReadLine();
        //        //פיצול של הטקסט למילים בלי רווחים ובלי תווים מיוחדים
        //        string[] words = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        //        List<string> textList = new List<string>(words);
        //        string code;
        //        foreach (string word in textList)
        //        {
        //            if (word == codeName)
        //            {
        //                code = word;
        //            }
        //            else
        //            {
        //                People people;
        //                Console.WriteLine("enter first name");
        //                string fn = Console.ReadLine();
        //                Console.WriteLine("enter lest name");
        //                string ln = Console.ReadLine();
        //                people = new People(fn, ln, codeName, "targater");
        //                Console.WriteLine($"codeName {codeName} does not exist. Creates a new record.");
        //                AddReporter(people);
        //            }
        //        }
        //        string query1 = $"SELECT * FROM IntelReports  WHERE target_id = '{code}' ";
        //    }
        //}
    }
}
