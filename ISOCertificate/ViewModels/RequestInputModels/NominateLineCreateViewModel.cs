using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class NominateLineCreateViewModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
        public int TeamTypeId { get; set; }
    }
}
