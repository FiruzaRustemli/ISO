namespace ISOCertificate.Models
{
    public class MenuRole
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string RoleId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Microsoft.AspNetCore.Identity.IdentityRole Role { get; set; }
    }
}
