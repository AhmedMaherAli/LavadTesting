using AutoMapper;
using InfraStructure.Services;
using LavadTesting.Infrastructure.DTOs;
using LavadTesting.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LavadTesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialPlatformsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<SocialPlatformsController> _logger;
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public SocialPlatformsController(IUnitOfWork unitOfWork, ILogger<SocialPlatformsController> logger, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> getSocialPlatformsUsingSpecificLanguage([FromHeader] string languageKey)
        {
            try
            {
                var language = await _unitOfWork.Languages.Get(x => x.Key == languageKey);

                var socialPlatformsTranslation = await _unitOfWork.SocialPlatformsTranslations.GetAll(x => x.LanguageId == language.Id, null, new List<string> { "Language" });
                return Ok(socialPlatformsTranslation);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something Went wrong with {nameof(getSocialPlatformsUsingSpecificLanguage)}");
                return StatusCode(500, "Internal server error, please try again later."); //
            }
        }

        [HttpGet("GetSocialPlatforms")]
        public async Task<ActionResult<IReadOnlyList<SocialPlatformDTO>>> getSocailPlatforms()
        {
            try
            {
                var socialPlatforms = await _unitOfWork.SocialPlatforms.GetAll();

                return Ok(mapper.Map<IList<SocialPlatformDTO>>(socialPlatforms));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went wrong with {nameof(getSocialPlatformsUsingSpecificLanguage)}");
                return StatusCode(500, "Internal server error, please try again later."); //
            }
        }

        [HttpGet("InvokeTheRequest")]
        public async Task<ActionResult<IReadOnlyList<SocialPlatformDTO>>> InvokeTheRequest()
        {
            
            var httpClient = httpClientFactory.CreateClient();
            HttpClientCrudService httpClientCrudService = new HttpClientCrudService(httpClient);
            var result = await httpClientCrudService.Execute();
            if(result!=null)
                return Ok(result);
            return BadRequest();
        }

    }
}
