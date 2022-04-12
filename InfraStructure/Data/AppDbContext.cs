using LavadTesting.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LavadTesting.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public  DbSet<Language> Languages { get; set; }
        public  DbSet<SocialPlatformTranslation> SocialPlatformTranslations { get; set; }
        public DbSet<SocialPlatform> SocialPlatforms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Direction).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<SocialPlatformTranslation>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.SocialPlatformId });
            });

            modelBuilder.HasSequence<int>("AffiliateCashOutRequestsFriendlyIdSequence");

            modelBuilder.HasSequence<int>("AffiliateProfileFriendlyIdSequence");

            modelBuilder.HasSequence<int>("ClientTopUpBalanceFriendlyIdSequence");

            modelBuilder.HasSequence<int>("InfluencerCashOutRequestsFriendlyIdSequence");

            modelBuilder.HasSequence<int>("InfluencerProfileFriendlyIdSequence");

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);




        }


    }
}
