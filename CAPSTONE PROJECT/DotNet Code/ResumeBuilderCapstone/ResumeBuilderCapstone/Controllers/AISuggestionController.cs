using Microsoft.AspNetCore.Mvc;
using ResumeBuilderCapstone.Services;
using ResumeBuilderCapstone.Models;

namespace ResumeBuilderCapstone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AISuggestionsController : ControllerBase
    {
        private readonly AISuggestionService _service;
        public AISuggestionsController(AISuggestionService service) => _service = service;

        /// <summary>
        /// Generate AI suggestions for a resume (Mock AI). Clears old suggestions by default.
        /// </summary>
        /// <param name="resumeId">Resume Id</param>
        /// <param name="clearOld">Optional: clear previous suggestions first (default: true)</param>
        [HttpPost("generate/{resumeId}")]
        public async Task<IActionResult> Generate(int resumeId, [FromQuery] bool clearOld = true)
        {
            var suggestions = await _service.GenerateSuggestionsAsync(resumeId, clearOld);
            if (suggestions == null || suggestions.Count == 0)
                return NotFound(new { message = "Resume not found or no suggestions generated." });

            return Ok(suggestions);
        }

        /// <summary>Get all suggestions for a resume.</summary>
        [HttpGet("resume/{resumeId}")]
        public async Task<IActionResult> GetByResume(int resumeId)
        {
            var items = await _service.GetByResumeAsync(resumeId);
            return Ok(items);
        }

        /// <summary>Get one suggestion by id.</summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        /// <summary>Delete one suggestion by id.</summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
