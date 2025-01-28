using ContatoInteligenteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContatoInteligenteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("avatar")]
        public async Task<IActionResult> GetAvatar()
        {
            try
            {
                var avatarUrl = await _gitHubService.GetOrganizationAvatarUrlAsync("takenet");
                return Ok(new { avatarUrl });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter avatar: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("repositories")]
        public async Task<IActionResult> GetTop5Repositories()
        {
            var repositories = await _gitHubService.GetTop5OldestCSharpRepositoriesAsync();
            return Ok(repositories);
        }
    }
}