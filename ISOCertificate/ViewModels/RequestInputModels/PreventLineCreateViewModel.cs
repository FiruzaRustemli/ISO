using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class PreventLineCreateViewModel
    {
        public string Action { get; set; }
        public string Person { get; set; }
        public DateTime? Date { get; set; }

    }
}
