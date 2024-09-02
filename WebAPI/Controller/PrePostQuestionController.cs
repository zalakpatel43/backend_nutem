using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrePostQuestionController : ControllerBase
    {
        private readonly IPrePostQuestionService _prePostQuestionService;

        public PrePostQuestionController(IPrePostQuestionService prePostQuestionService)
        {
            _prePostQuestionService = prePostQuestionService;
        }

        /// <summary>
        /// Get all active pre/post questions.
        /// </summary>
        /// <returns>List of active pre/post questions.</returns>
        [HttpGet("GetAllPrePostQuestions")]
        public async Task<IActionResult> GetAllPrePostQuestions()
        {
            try
            {
                var data = await _prePostQuestionService.GetAllPrePostQuestionsAsync().ToListAsync(); // Assuming .ToListAsync() is used for async operation
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging setup)
                // e.g., _logger.LogError(ex, "An error occurred while fetching pre/post questions.");

                // Return a generic error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
