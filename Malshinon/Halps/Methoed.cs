using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Halps
{
    public class Methoed
    {
        public string GetSCFromTest(string text)
        {
            string[] words = text.Split(' ');
            string TSC = null!;
            foreach (string w in words)
            {
                if (w[0] >= 65 && w[0] < 97)
                {
                    TSC = w;
                    break;
                }
            }
            return TSC;
        }
    }
}
