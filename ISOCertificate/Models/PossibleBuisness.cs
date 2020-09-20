using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class PossibleBuisness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Investigate> Investigates { get; set; }

    }
}
