using AutoMapper;
using LavadTesting.Infrastructure.DTOs;
using LavadTesting.Infrastructure.Interfaces;
using LavadTesting.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Helpers
{
    class PlatformNameResolver : IValueResolver<SocialPlatform, SocialPlatformDTO, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public PlatformNameResolver(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public string Resolve(SocialPlatform source, SocialPlatformDTO destination, string destMember, ResolutionContext context)
        {
            var languageKey = CultureInfo.DefaultThreadCurrentCulture.Name;

            var language = unitOfWork.Languages.Get(l => l.Key == languageKey).Result;
            var socialPlaformsTranslation = unitOfWork.SocialPlatformsTranslations.Get(platFormTrans => platFormTrans.LanguageId == language.Id && platFormTrans.SocialPlatformId == source.Id).Result;;
            return socialPlaformsTranslation.Name;
        }
    }
}
