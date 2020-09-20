using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class MaterialCreateViewModel
    {
        public int MaterialCategoryId { get; set; }
        public int MaterialReleasedId { get; set; }
        public string QuantityReleased { get; set; }
        public float Duration { get; set; }
        public string Pollution { get; set; }
        public string QuantityRecovered { get; set; }
    }
}
