using LavadTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadTesting.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {


        IGenericRepository<SocialPlatform> SocialPlatforms { get; }
        IGenericRepository<SocialPlatformTranslation> SocialPlatformsTranslations { get; }
        IGenericRepository<Language> Languages { get; }
        public Task<int> Save();


    }
}
