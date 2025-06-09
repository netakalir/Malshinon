using System;
using Malshinon.Models;


namespace Malshinon
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnection connection = new SQLConnection();
            connection.GetConnecet();
            connection.CloseConnecte();
        }
    }
}
