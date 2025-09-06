using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderCapstone.Models;
using ResumeBuilderCapstone.Services;

namespace ResumeBuilderCapstone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EducationController : ControllerBase
    {
        private readonly EducationService _service;
        public EducationController(EducationService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(Education item)
        {
            var created = await _service.CreateAsync(item);
            return Ok(created);
        }

        [HttpGet("by-resume/{resumeId:int}")]
        public async Task<IActionResult> GetByResume(int resumeId)
        {
            var list = await _service.GetByResumeAsync(resumeId);
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Education item)
        {
            if (id != item.EducationId) return BadRequest("Id mismatch.");
            var ok = await _service.UpdateAsync(item);
            if (!ok) return NotFound();
            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Deleted" });
        }
    }
}
