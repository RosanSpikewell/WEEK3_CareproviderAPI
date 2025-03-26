using CareProviderAPI.Data.DTOs.CareProviderDTOs;
using CareProviderAPI.Services.Implementations;
using CareProviderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareProviderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareProviderController : ControllerBase
    {
        private readonly ICareProviderService careProviderService;

        public CareProviderController(ICareProviderService careProviderService)
        {
            this.careProviderService = careProviderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareProviderDto>>> GetAll()
        {
            var providers = await careProviderService.GetAllAsync();
            return Ok(providers);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<CareProviderDto>> GetById(Guid id)
        {
            var provider = await careProviderService.GetByIdAsync(id);
            if (provider == null) return NotFound("Care Provider not found.");
            return Ok(provider);
        }

        [HttpGet]
        [Route("by-department/{departmentId:int}")]
        public async Task<ActionResult<IEnumerable<CareProviderDto>>> GetByDepartment(int departmentId)
        {
            var providers = await careProviderService.GetByDepartmentAsync(departmentId);

            if (providers == null || !providers.Any())
            {
                return NotFound("No providers found for the given department.");
            }

            return Ok(providers);
        }


        [HttpGet]
        [Route("filter-experience/{years:int}")]
        public async Task<ActionResult<IEnumerable<CareProviderDto>>> FilterByExperience(int years)
        {
            var providers = await careProviderService.FilterByExperienceAsync(years);
            return Ok(providers);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateCareProviderDto providerDto)
        {
            var createdProvider = await careProviderService.AddAsync(providerDto);

            return CreatedAtAction(nameof(GetById), new { id = createdProvider.Id }, createdProvider);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCareProviderDto providerDto)
        {
            await careProviderService.UpdateAsync(id, providerDto);
            return Ok(new { message = "Data Updated"});
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await careProviderService.DeleteAsync(id);
            return Ok(new { message = "Delete Successfully"});
        }
    }
}
