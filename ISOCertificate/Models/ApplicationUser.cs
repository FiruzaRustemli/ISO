using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ISOCertificate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoURL { get; set; }
        public DateTime Birthday { get; set; }
        public byte Status { get; set; }
        public byte Gender { get; set; }
        public string RefreshToken { get; set; }
        public int VerifyCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
