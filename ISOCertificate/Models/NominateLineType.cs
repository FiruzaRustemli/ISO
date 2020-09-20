using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class NominateLineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<NominateLine> NominateLine { get; set; }
    }
}
