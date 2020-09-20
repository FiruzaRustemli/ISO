namespace ISOCertificate.Models
{
    public class MenuModule
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int ModuleId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Module Module { get; set; }
    }
}
