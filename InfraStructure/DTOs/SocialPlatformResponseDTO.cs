using LavadTesting.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.DTOs
{
    public class SocialPlatformResponseDTO
    {
        public int status { get; set; }
        public SocialPlatformDTO[] Response { get; set; }
        public object error { get; set; }
    }

}
