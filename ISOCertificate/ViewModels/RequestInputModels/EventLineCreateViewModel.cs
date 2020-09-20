using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class EventLineCreateViewModel
    {
        public DateTime? Date { get; set; }
        public decimal Time { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
