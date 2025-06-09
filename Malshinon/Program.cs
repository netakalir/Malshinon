using System;
using Malshinon.Models;


namespace Malshinon
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnection connection = new SQLConnection();
            SingelDAL singelDAL = new SingelDAL();
            //connection.GetConnecet();
            //connection.CloseConnecte();
            People reporter = new People("Netanel","Kalir","n","reporter");
            People targat = new People("Gaby","Taler","g", "targater");
            singelDAL.AddReporter(reporter);
            singelDAL.AddTargater(targat);
        }
    }
}
