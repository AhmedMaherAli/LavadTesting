using AutoMapper;
using InfraStructure.Helpers;
using LavadTesting.Infrastructure.DTOs;
using LavadTesting.Infrastructure.Interfaces;
using LavadTesting.Models;
using System.Globalization;

namespace LavadTesting.Infrastructure.Configuration
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {


            CreateMap<SocialPlatform, SocialPlatformDTO>()
                .ForMember(x=>x.Name, o=>o.ResolveUsing<PlatformNameResolver>());
            
        }
    }
}
