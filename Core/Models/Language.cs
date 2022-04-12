using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LavadTesting.Models
{
    public partial class Language
    {
        public Language()
        {
            SocialPlatformTranslations = new HashSet<SocialPlatformTranslation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Key { get; set; }
        public bool IsDefault { get; set; }
        public int DisplayOrder { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public string Direction { get; set; }

        [InverseProperty(nameof(SocialPlatformTranslation.Language))]
        public virtual ICollection<SocialPlatformTranslation> SocialPlatformTranslations { get; set; }
    }
}
