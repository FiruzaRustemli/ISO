namespace ISOCertificate.Models
{
    public class InvestigateLine
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
        public int LineTypeId { get; set; }

        public virtual Investigate Investigate { get; set; }
        public virtual LineType LineType { get; set; }

    }
}
