using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class EvaluationLine
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public string Notes { get; set; }
        public DateTime? Date { get; set; }

        public virtual Investigate Investigate { get; set; }

    }
}
