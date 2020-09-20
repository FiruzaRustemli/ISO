using ISOCertificate.DAL.EntityConfiguration;
using ISOCertificate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ISOCertificate.DAL
{
    public class CertificateDbContext : IdentityDbContext<ApplicationUser>
    {
        public CertificateDbContext(DbContextOptions<CertificateDbContext> options)
          : base(options)
        {
        }
        public DbSet<BodilyLocationType> BodilyLocationType { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<GroundConditionType> GroundConditionType { get; set; }
        public DbSet<GroundType> GroundType { get; set; }
        public DbSet<IlluminationType> IlluminationType { get; set; }
        public DbSet<IlnessType> IlnessTypes { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<InjuredActionType> InjuredActionType { get; set; }
        public DbSet<InjuryType> InjuryType { get; set; }
        public DbSet<Investigate> Investigate { get; set; }
        public DbSet<InvestigateLine> InvestigateLine { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<MaterialCategory> MaterialCategorie { get; set; }
        public DbSet<MaterialReleased> MaterialReleasedie { get; set; }
        public DbSet<OccurenceReason> OccurenceReason { get; set; }
        public DbSet<OccurenceType> OccurenceType { get; set; }
        public DbSet<ReleasedToType> ReleasedToType { get; set; }
        public DbSet<ReleaseType> ReleaseType { get; set; }
        public DbSet<UnSafeConditionType> UnSafeConditionType { get; set; }
        public DbSet<UnSafeFactType> UnSafeFactType { get; set; }
        public DbSet<WheatherType> WheatherType { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<MenuModule> MenuModule { get; set; }
        public DbSet<MenuRole> MenuRole { get; set; }
        public DbSet<LineType> LineType { get; set; }
        public DbSet<OccurenceCause> OccurenceCause { get; set; }
        public DbSet<OutcomePeople> OutcomePeople { get; set; }
        public DbSet<OutcomeProperty> OutcomeProperty { get; set; }
        public DbSet<OutcomeEnviroment> OutcomeEnviroment { get; set; }
        public DbSet<OutcomeBuisness> OutcomeBuisness { get; set; }
        public DbSet<PossiblePeople> PossiblePeople { get; set; }
        public DbSet<PossibleProperty> PossibleProperty { get; set; }
        public DbSet<PossibleBuisness> PossibleBuisness { get; set; }
        public DbSet<PossibleEnviroment> PossibleEnviroment { get; set; }
        public DbSet<LessonLearned> LessonLearned { get; set; }
        public DbSet<NominateLineType> NominateLineType { get; set; }
        public DbSet<EventLine> EventLine { get; set; }
        public DbSet<EvaluationLine> EvaluationLine { get; set; }
        public DbSet<PreventLine> PreventLine { get; set; }
        public DbSet<NominateLine> NominateLine { get; set; }
        public DbSet<InvestigateUnsafe> InvestigateUnsafe { get; set; }
        public DbSet<InvestigateUnsafeFact> InvestigateUnsafeFact { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new BodilyLocationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroundConditionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroundTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IlluminationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IlnessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new InjuredActionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InjuryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvestigateLineConfiguration());
            modelBuilder.ApplyConfiguration(new LineTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialReleasedConfiguration());
            modelBuilder.ApplyConfiguration(new OccurenceReasonConfiguration());
            modelBuilder.ApplyConfiguration(new OccurenceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OccurenceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReleasedToTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReleaseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnSafeConditionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnSafeFactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WheatherTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
