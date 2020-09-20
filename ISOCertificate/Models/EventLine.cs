using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class EventLine
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public DateTime? Date { get; set; }
        public string  Time { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public virtual Investigate Investigate { get; set; }
    }
}
