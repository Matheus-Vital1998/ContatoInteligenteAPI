using ContatoInteligenteAPI.Models;

namespace ContatoInteligenteAPI.Repositorys.Interface
{
    public interface IGitHubRepository
    {
        Task<string> GetOrganizationAvatarUrlAsync(string organization);
        Task<List<RepositoryModel>> GetOrganizationRepositoriesAsync(string organization);
    }
}
