using AutoMapper;
using CareProviderAPI.Data.DTOs.ExperienceDTOs;
using CareProviderAPI.Services.Implementations;
using CareProviderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;
        private readonly IMapper mapper;

        public ExperienceController(IExperienceService experienceService,IMapper mapper)
        {
            this.experienceService = experienceService;
            this.mapper = mapper;
        }

        [HttpGet("by-provider/{providerId}")]
        public async Task<ActionResult<IEnumerable<ExperienceDto>>> GetByProviderId(Guid providerId)
        {
            var experiences = await experienceService.GetByProviderIdAsync(providerId);
            return Ok(experiences);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ExperienceDto experienceDto)
        {
            await experienceService.AddAsync(experienceDto);
            return Ok("Experience added successfully.");
        }
    }
}
