using AutoMapper;
using ISOCertificate.Models;
using ISOCertificate.ViewModels.RequestOutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Profiles
{
    public class ModulesProfile : Profile
    {
        public ModulesProfile()
        {
            CreateMap<Module, GetModulesOutputModel>();
        }
    }
}
