namespace ISOCertificate.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string Attachment { get; set; }

        public virtual Investigate Investigate { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
