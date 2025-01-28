using ContatoInteligenteAPI.Models;
using ContatoInteligenteAPI.Repositorys.Interface;
using ContatoInteligenteAPI.Services.Interfaces;

namespace ContatoInteligenteAPI.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public async Task<string> GetOrganizationAvatarUrlAsync(string organization)
        {
            return await _gitHubRepository.GetOrganizationAvatarUrlAsync(organization);
        }

        public async Task<List<RepositoryModel>> GetTop5OldestCSharpRepositoriesAsync()
        {
            var repositories = await _gitHubRepository.GetOrganizationRepositoriesAsync("takenet");

            if (repositories == null || repositories.Count == 0)
            {
                Console.WriteLine("Nenhum repositório retornado.");
                return new List<RepositoryModel>();
            }

            return repositories
                .Where(repo => string.Equals(repo.Language, "C#", StringComparison.OrdinalIgnoreCase)) // Filtro C#
                .OrderBy(repo => repo.CreatedAt) // Verifique se CreatedAt está correto
                .Take(5)
                .ToList();
        }

    }
}