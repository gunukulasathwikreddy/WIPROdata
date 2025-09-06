using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilderCapstone.Models;
using ResumeBuilderCapstone.Services;

namespace ResumeBuilderCapstone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ResumeController : ControllerBase
    {
        private readonly ResumeService _service;
        public ResumeController(ResumeService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(Resume resume)
        {
            var created = await _service.CreateAsync(resume);
            return Ok(created);
        }

        [HttpGet("{resumeId:int}")]
        public async Task<IActionResult> GetById(int resumeId)
        {
            var res = await _service.GetByIdAsync(resumeId);
            if (res == null) return NotFound();
            return Ok(res);
        }

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var list = await _service.GetByUserAsync(userId);
            return Ok(list);
        }

        [HttpPut("{resumeId:int}")]
        public async Task<IActionResult> Update(int resumeId, Resume resume)
        {
            if (resumeId != resume.ResumeId) return BadRequest("Id mismatch.");
            var ok = await _service.UpdateAsync(resume);
            if (!ok) return NotFound();
            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{resumeId:int}")]
        public async Task<IActionResult> Delete(int resumeId)
        {
            var ok = await _service.DeleteAsync(resumeId);
            if (!ok) return NotFound();
            return Ok(new { message = "Deleted" });
        }
    }
}

