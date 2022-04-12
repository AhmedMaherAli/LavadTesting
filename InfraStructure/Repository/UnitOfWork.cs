using LavadTesting.Infrastructure.Data;
using LavadTesting.Infrastructure.Interfaces;
using LavadTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LavadTesting.Infrastructure.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IGenericRepository<SocialPlatform> _socialPlatforms;
        private IGenericRepository<SocialPlatformTranslation> _socialPlatformTranslation;
        private IGenericRepository<Language> _language;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IGenericRepository<SocialPlatform> SocialPlatforms => _socialPlatforms ?? new GenericRepository<SocialPlatform>(_appDbContext);
        public IGenericRepository<SocialPlatformTranslation> SocialPlatformsTranslations => _socialPlatformTranslation ?? new GenericRepository<SocialPlatformTranslation>(_appDbContext);
        public IGenericRepository<Language> Languages => _language ?? new GenericRepository<Language>(_appDbContext);


        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<int> Save()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
