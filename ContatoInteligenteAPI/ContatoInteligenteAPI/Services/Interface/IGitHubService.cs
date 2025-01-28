using ContatoInteligenteAPI.Models;

namespace ContatoInteligenteAPI.Services.Interfaces
{
    public interface IGitHubService
    {
        Task<string> GetOrganizationAvatarUrlAsync(string organization);
        Task<List<RepositoryModel>> GetTop5OldestCSharpRepositoriesAsync();
    }
}