using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL
{
    public class IntalDAL
    {
        private SQLConnection sqlConn;
        public IntalDAL(SQLConnection _sqlConn)
        {
            sqlConn = _sqlConn;
        }
        public IntelReports InsertIntelReport(int reporter_id, int targater_id, string text) //
        {
            IntelReports Report = null;
            try
            {
                var conn = sqlConn.GetConnecet();
                //Console.WriteLine("To report enter your name code");
                //string RSC = Console.ReadLine();
                ////PersonIdentification(RSC);
                //People reportr =  FindPersonBySecretCode(RSC);
                //string secrtCode = GetSCFromTest();
                //People targetr = null!;
                //string query = $"SELECT * FROM people WHERE people.secretCode = '{secrtCode}'";
                //var SqlCommend = new MySqlCommand(query, conn);
                //var reader = SqlCommend.ExecuteReader();
                //if(reader.HasRows)
                //{
                //    while(reader.Read())
                //    {
                //        string firstName = reader.GetString("firstName");
                //        string lestName = reader.GetString("lestName");
                //        string Code = reader.GetString("secretCode");
                //        string type = reader.GetString("type");
                //        int NumReports = reader.GetInt32("NumReports");
                //        int NumMentions = reader.GetInt32("NumMentions");
                //        targetr = new(firstName, lestName, Code, type, NumReports, NumMentions);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("enter first name");
                //    string FN = Console.ReadLine();
                //    Console.WriteLine("enter lest name");
                //    string LN = Console.ReadLine();
                //    targetr = new(FN, LN, secrtCode, "targater");
                //}

                string new_query = @"INSERT INTO intelreports
                                (reporter_id, target_id, text) 
                                VALUES(@ReporterId, @TargatId, @Text)";
                var SqlCommend = new MySqlCommand(new_query, conn);
                SqlCommend.Parameters.AddWithValue("@ReporterId", reporter_id);
                SqlCommend.Parameters.AddWithValue("@TargatId", targater_id);
                SqlCommend.Parameters.AddWithValue("@Text", text);
                var reder = SqlCommend.ExecuteReader();
                sqlConn.CloseConnecte();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Report;
        }

    }
}
