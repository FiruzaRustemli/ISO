using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Models
{
    public class Investigate
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime? DateTime { get; set; }
        public string  Time { get; set; }
        public string Area { get; set; }
        public string Activity { get; set; }
        public int? OccurenceReasonId { get; set; }
        public int? OccurenceTypeId { get; set; }
        public int? WheatherTypeId { get; set; }
        public int? GroundTypeId { get; set; }
        public int? GroundConditionTypeId { get; set; }
        public int? IlluminationTypeId { get; set; }
        public int? ContactTypeId { get; set; }
        public int? InjuryTypeId { get; set; }
        public int? IlnessTypeId { get; set; }
        public int? BodilyLocationTypeId { get; set; }
        public int? InjuredActionTypeId { get; set; }
        public int? ReleaseTypeId { get; set; }
        public int? ReleasedToTypeId { get; set; }
        //public IEnumerable<int?> UnSafeFactTypeId { get; set; }
        //public IEnumerable<int?> UnSafeConditionTypeId { get; set; }
        public string DescriptionIncident { get; set; }
        public string DescriptionImmediate { get; set; } 
        public byte? Status { get; set; }
        public string UserId { get; set; }
        public int? SType { get; set; }
        public int ConfirmStatus { get; set; }

        //additional 2nd users column

        public int? OccurenceCauseId { get; set; }
        public int? OutcomePeopleId { get; set; }
        public int? OutcomePropertyId { get; set; }
        public int? OutcomeEnviromentId { get; set; }
        public int? OutcomeBuisnessId { get; set; }
        public int? PossiblePeopleId { get; set; }
        public int? PossiblePropertyId { get; set; }
        public int? PossibleEnviromentId { get; set; }
        public int? PossibleBuisnessId { get; set; }
        public int? LessonLearnedId { get; set; }
        public string BriefDecription { get; set; }
        public string ReasonDescription { get; set; }
        public string IdentifyDescription { get; set; }

        public virtual OccurenceReason OccurenceReason { get; set; }
        public virtual OccurenceType OccurenceType { get; set; }
        public virtual WheatherType WheatherType { get; set; }
        public virtual GroundType GroundType { get; set; }
        public virtual GroundConditionType GroundConditionType { get; set; }
        public virtual IlluminationType IlluminationType { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual InjuryType InjuryType { get; set; }
        public virtual IlnessType IlnessType { get; set; }
        public virtual BodilyLocationType BodilyLocationType { get; set; }
        public virtual InjuredActionType InjuredActionType { get; set; }
        public virtual ReleaseType ReleaseType { get; set; }
        public virtual ReleasedToType ReleasedToType { get; set; }

        public virtual InvestigateUnsafeFact UnSafeFactType { get; set; }
        public virtual InvestigateUnsafe UnSafeConditionType { get; set; }

        public virtual OccurenceCause OccurenceCause { get; set; }
        public virtual OutcomePeople OutcomePeople { get; set; }
        public virtual OutcomeEnviroment OutcomeEnviroment { get; set; }
        public virtual OutcomeProperty OutcomeProperty { get; set; }
        public virtual OutcomeBuisness OutcomeBuisness { get; set; }
        public virtual PossiblePeople PossiblePeople { get; set; }
        public virtual PossibleProperty PossibleProperty { get; set; }
        public virtual PossibleEnviroment PossibleEnviroment { get; set; }
        public virtual PossibleBuisness PossibleBuisness { get; set; }
        public virtual LessonLearned LessonLearned { get; set; }


        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<InvestigateLine> InvestigateLines { get; set; }
        public virtual ICollection<NominateLine> NominateLine { get; set; }
        public virtual ICollection<EventLine> EventLines { get; set; }
        public virtual ICollection<EvaluationLine> EvaluationLines { get; set; }
        public virtual ICollection<PreventLine> PreventLines { get; set; }

    }
}
