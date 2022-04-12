using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LavadTesting.Models
{
    public partial class SocialPlatform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
        public bool Deleted { get; set; }
        public bool IsLinkingEnabled { get; set; }   
    }
}
