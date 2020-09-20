using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<MenuModule> menUModules { get; set; }
    }
}
