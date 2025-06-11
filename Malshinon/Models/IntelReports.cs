using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public class IntelReports
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargatId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }



        public IntelReports(int reporterId, int targatId, string text)
        {
            ReporterId = reporterId;
            TargatId = targatId;
            Text = text;
        }
    }
}
