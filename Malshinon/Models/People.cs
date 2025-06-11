using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LestName { get; set; }
        public string SecretCode { get; set; }
        public string Type { get; set; }
        public int NumReports { get; set; }
        public int NumMentions { get; set; }


        public People(string firsName, string lestName, string secretCode, string type, int numReports = 0, int numMentions = 0)
        {
            FirsName = firsName;
            LestName = lestName;
            SecretCode = secretCode;
            Type = type;
            NumReports = numReports;
            NumMentions = numMentions;
        }
    }
}

