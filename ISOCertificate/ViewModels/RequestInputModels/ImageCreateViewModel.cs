using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class ImageCreateViewModel
    {
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
