using ISOCertificate.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class InvestigateCreateIncidentViewModel
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int OccurenceCauseId { get; set; }
        public int OutcomePeopleId { get; set; }
        public int OutcomePropertyId { get; set; }
        public int OutcomeEnviromentId { get; set; }
        public int OutcomeBuisnessId { get; set; }
        public int PossiblePeopleId { get; set; }
        public int PossiblePropertyId { get; set; }
        public int PossibleEnviromentId { get; set; }
        public int PossibleBuisnessId { get; set; }
        public int LessonLearnedId { get; set; }
        public string BriefDecription { get; set; }
        public string ReasonDescription { get; set; }
        public string IdentifyDescription { get; set; }
        public byte Status { get; set; }
        public string UserId { get; set; }
        public int SType { get; set; }
        public int ConfirmStatus { get; set; }


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

        public IEnumerable<EventLineCreateViewModel> EventLines { get; set; }
        public IEnumerable<EvaluationLineCreateViewModel> EvaluationLines { get; set; }
        public IEnumerable<PreventLineCreateViewModel> PreventLines { get; set; }
        public IEnumerable<NominateLineCreateViewModel> NominateLines { get; set; }
        public IEnumerable<ImageCreateViewModel> Images { get; set; }
        public ICollection<IFormFile> AllPhotos { get; set; }
    }
}
