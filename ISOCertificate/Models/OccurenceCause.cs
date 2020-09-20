using System.Collections.Generic;

namespace ISOCertificate.Models
{
    public class OccurenceCause
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Investigate> Investigates { get; set; }

    }
}
