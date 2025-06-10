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
<<<<<<< HEAD
            //singelDAL.GetPersonBySecretCode();
            singelDAL.UpdateReportCounts();
=======
            singelDAL.GetPersonBySecretCode();
>>>>>>> 6405603d0f031f69ce3513c30fbbe878c1ca4b2e
        }
    }
}
