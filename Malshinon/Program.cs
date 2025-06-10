using System;
using Malshinon.Models;


namespace Malshinon
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnection DB = new SQLConnection();
            SingelDAL singelDAL = new SingelDAL(DB);
            //DB.GetConnecet();
            //DB.CloseConnecte();
            //People reporter = new People("Avi","Levi","A","reporter");
            //People targat = new People("Gaby","Taler","g", "targater");
            //singelDAL.AddReporter(reporter);
            //singelDAL.AddTargater(targat);
            //singelDAL.PersonIdentification("a");
            //singelDAL.DeleteBySecretCode();
            //singelDAL.Updateperson();
            singelDAL.UpdateReportCounts();
            singelDAL.GetPersonBySecretCode();
        }
    }
}
