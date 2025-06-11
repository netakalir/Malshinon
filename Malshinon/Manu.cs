using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DAL;

namespace Malshinon.Models
{
    public class Manu()
    {
        private SQLConnection DB;
        private PeopleDAL PeopleDAL;
        private IntalDAL IntalDAL;

        public void manu(SQLConnection db, PeopleDAL peopleDal, IntalDAL intalDal)
        {
            DB = db;
            PeopleDAL = peopleDal;
            IntalDAL = intalDal;
        }

        public void InsertReportr()
        {
            Console.WriteLine("enter first name");
            string FN = Console.ReadLine()!;
            Console.WriteLine("enter lest name");
            string LN = Console.ReadLine()!;
            Console.WriteLine("enter secret code");
            string SC = Console.ReadLine()!;
            People reporter = new People(FN, LN, SC, "reporter");
            PeopleDAL.InsertNewPerson(reporter);
        }

        public void InsertTargater()
        {
            Console.WriteLine("enter first name");
            string FN = Console.ReadLine()!;
            Console.WriteLine("enter lest name");
            string LN = Console.ReadLine()!;
            Console.WriteLine("enter secret code");
            string SC = Console.ReadLine()!;
            People targater = new People(FN!, LN!, SC!, "targater");
            PeopleDAL.InsertNewPerson(targater);
        }


        public void ShouManu()
        {
            Console.WriteLine("To identification enter secrat code");
            string RSC = Console.ReadLine()!;
            if(PeopleDAL.PersonIdentification(RSC!))
            {
                People reporter = PeopleDAL.GetPersonBySecretCode(RSC!);
                Console.WriteLine("Identification of people was successful.");
                Thread.Sleep(2000);
                Console.WriteLine("Provide a code name for the target.");
                string TSC = Console.ReadLine()!;
                People targeter = PeopleDAL.GetPersonBySecretCode(TSC!);
                Console.WriteLine("feel free to reporting");
                string Text = Console.ReadLine()!;
                IntalDAL.InsertIntelReport(reporter.Id, targeter.Id, Text!);
            }
            
            else
            {
                Console.WriteLine($"codeName {RSC} does not exist.");
                
            }
        }
    }
}
