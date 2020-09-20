using ISOCertificate.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace ISOCertificate.ViewModels.RequestInputModels
{
    public class InvestigateCreateViewModel
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Time { get; set; }
        public string Area { get; set; }
        public string Activity { get; set; }
        public int OccurenceReasonId { get; set; }
        public int OccurenceTypeId { get; set; }
        public int WheatherTypeId { get; set; }
        public int GroundTypeId { get; set; }
        public int GroundConditionTypeId { get; set; }
        public int IlluminationTypeId { get; set; }
        public int ContactTypeId { get; set; }
        public int InjuryTypeId { get; set; }
        public int IlnessTypeId { get; set; }
        public int BodilyLocationTypeId { get; set; }
        public int InjuredActionTypeId { get; set; }
        public int ReleaseTypeId { get; set; }
        public int ReleasedToTypeId { get; set; }
        public IEnumerable<int?> UnSafeFactTypeId { get; set; }
        public IEnumerable<int?> UnSafeConditionTypeId { get; set; }
        public string DescriptionIncident { get; set; }
        public string DescriptionImmediate { get; set; }


        public byte Status { get; set; }
        public string UserId { get; set; }
        public int SType { get; set; }


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
        //public virtual UnSafeFactType UnSafeFactType { get; set; }
        //public virtual UnSafeConditionType UnSafeConditionType { get; set; }

        public IEnumerable<MaterialCreateViewModel> Materials { get; set; }
        public IEnumerable<InvestigateLineCreateViewModel> InvestigateLines { get; set; }
        public IEnumerable<ImageCreateViewModel> Images { get; set; }
        public ICollection<IFormFile> AllPhotos { get; set; }

    }
}
