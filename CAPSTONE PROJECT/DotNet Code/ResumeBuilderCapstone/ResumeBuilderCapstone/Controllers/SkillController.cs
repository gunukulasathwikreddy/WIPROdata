using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderCapstone.Models;
using ResumeBuilderCapstone.Services;

namespace ResumeBuilderCapstone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SkillController : ControllerBase
    {
        private readonly SkillService _service;
        public SkillController(SkillService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(Skill item) =>
            Ok(await _service.CreateAsync(item));

        [HttpGet("by-resume/{resumeId:int}")]
        public async Task<IActionResult> GetByResume(int resumeId) =>
            Ok(await _service.GetByResumeAsync(resumeId));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Skill item)
        {
            if (id != item.SkillId) return BadRequest("Id mismatch.");
            var ok = await _service.UpdateAsync(item);
            return ok ? Ok(new { message = "Updated" }) : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? Ok(new { message = "Deleted" }) : NotFound();
        }
    }
}
