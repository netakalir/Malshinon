using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DAL;

namespace Malshinon.Models
{
    public class Manu
    {

        public void init ()
        {
            SQLConnection DB = new SQLConnection();
            PeopleDAL peopleDAL = new PeopleDAL(DB);
            IntalDAL intalDAL = new IntalDAL(DB);
        }
        public void ShouManu(SQLConnection DB, PeopleDAL peopleDAL, IntalDAL intalDAL)
        {
            Console.WriteLine("To identification enter secrat code");
            string RSC = Console.ReadLine();
            if(peopleDAL.PersonIdentification(RSC))
            {
                Console.WriteLine("Identification of people was successful.");


            }
            
            else
            {
                Console.WriteLine($"codeName {RSC} does not exist.");
                
            }


            People reportr = singelDAL.FindPersonBySecretCode(RSC);
            Console.WriteLine("Feel free to report.");
            string text = Console.ReadLine();
            string TSC = singelDAL.GetSCFromTest(text);
            People targater = singelDAL.FindPersonBySecretCode(RSC);
            singelDAL.InsertIntelReport(reportr.Id, targater.Id, text);




        //check if reporter Exists

            //if exists 
                

            







            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("To report press");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
