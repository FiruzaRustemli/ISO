namespace ISOCertificate.Models
{
    public class InvestigateUnsafeFact
    {
        public int Id { get; set; }

        public int? InvestigateId { get; set; }
        public virtual Investigate Investigate { get; set; }

        public int? UnSafeFactTypeId { get; set; }
        public virtual UnSafeFactType UnSafeFactType { get; set; }
    }
}
