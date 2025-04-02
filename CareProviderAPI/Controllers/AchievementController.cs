using AutoMapper;
using CareProviderAPI.Data.DTOs.AchievementDTOs;
using CareProviderAPI.Services.Implementations;
using CareProviderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService achievementService;
        private readonly IMapper mapper;

        public AchievementController(IAchievementService achievementService,IMapper mapper)
        {
            this.achievementService = achievementService;
            this.mapper = mapper;
        }

    
        [HttpGet("by-provider/{providerId}")]
        public async Task<ActionResult<IEnumerable<AchievementDto>>> GetByProviderId(Guid providerId)
        {
            var achievements = await achievementService.GetByProviderIdAsync(providerId);
            return Ok(achievements);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AchievementDto achievementDto)
        {
            await achievementService.AddAsync(achievementDto);
            return Ok("Achievement added successfully.");
        }
    }
}
