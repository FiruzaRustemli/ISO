namespace ISOCertificate.Models
{
    public class InvestigateUnsafe
    {
        public int Id { get; set; }

        public int? InvestigateId { get; set; }
        public virtual Investigate Investigate { get; set; }

        public int? UnSafeConditionTypeId { get; set; }
        public virtual UnSafeConditionType UnSafeConditionType { get; set; }
    }
}
