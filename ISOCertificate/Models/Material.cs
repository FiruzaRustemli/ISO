namespace ISOCertificate.Models
{
    public class Material
    {
        public int Id { get; set; }
        public int InvestigateId { get; set; }
        public int MaterialCategoryId { get; set; }
        public int MaterialReleasedId { get; set; }
        public double QuantityReleased { get; set; }
        public double Duration { get; set; }
        public double Pollution { get; set; }
        public double QuantityRecovered { get; set; }

        public virtual Investigate Investigate { get; set; }
        public virtual MaterialCategory MaterialCategory { get; set; }
        public virtual MaterialReleased MaterialReleased { get; set; }
    }
}
