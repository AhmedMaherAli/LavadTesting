using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LavadTesting.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(SocialPlatformId), Name = "IX_SocialPlatformTranslations_SocialPlatformId")]
    public partial class SocialPlatformTranslation
    {
        [Key]
        public int SocialPlatformId { get; set; }
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("SocialPlatformTranslations")]
        public virtual Language Language { get; set; }
    }
}
