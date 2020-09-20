using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class NominateLine
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
        public int TeamTypeId { get; set; }

        public virtual Investigate Investigate { get; set; }
        public virtual NominateLineType TeamType { get; set; }

    }
}
