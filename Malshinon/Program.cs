using System;
using Malshinon.DAL;
using Malshinon.Models;


namespace Malshinon
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnection db = new SQLConnection();
            PeopleDAL peopleDal = new PeopleDAL(db);
            IntalDAL intalDal = new IntalDAL(db);
            Manu manu = new Manu(db, peopleDal, intalDal);

            //manu.InsertReportr("Mair", "Tom", "M", "reportr");
            manu.ShouManu();












            //People reporter;
            //People targat = new People("Mair", "Tom", "M", "targater");
            //singelDAL.AddReporter(reporter);
            //singelDAL.AddTargater(targat);
            //singelDAL.PersonIdentification("P");
            //People target = singelDAL.PersonIdentification(codeName);
            //singelDAL.DeleteBySecretCode();
            //singelDAL.Updateperson();
            //singelDAL.UpdateReportCounts();
            //singelDAL.GetPersonBySecretCode();
            //singelDAL.InsertIntelReport();
            //Manu manu = new Manu();
            //manu.ShouManu();
        }
    }
}
