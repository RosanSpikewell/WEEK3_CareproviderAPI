using CareProviderAPI.Data.DTOs.DepartmentDTOs;
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

    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var departments = await departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            var department = await departmentService.GetByIdAsync(id);
            if (department == null) return NotFound("Department not found.");
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DepartmentDto departmentDto)
        {
            var createdDepartment = await departmentService.AddAsync(departmentDto);

            return CreatedAtAction(nameof(GetById), new { id = createdDepartment.Id }, createdDepartment);
        }

    }
}
