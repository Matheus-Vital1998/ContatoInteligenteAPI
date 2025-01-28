using ContatoInteligenteAPI.Models;
using ContatoInteligenteAPI.Repositorys.Interface;
using Newtonsoft.Json;

namespace ContatoInteligenteAPI.Repositorys
{
    public class GitHubRepository : IGitHubRepository
    {
        private readonly HttpClient _httpClient;

        public GitHubRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharp-App");
        }

        public async Task<string> GetOrganizationAvatarUrlAsync(string organization)
        {
            var url = $"https://api.github.com/orgs/{organization}";
            Console.WriteLine($"GET {url}");

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
                throw new HttpRequestException($"Erro ao buscar avatar: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Resposta Avatar: {content}");

            var organizationData = JsonConvert.DeserializeObject<OrganizationModel>(content);

            // Verificar se o AvatarUrl é nulo antes de retornar
            if (string.IsNullOrEmpty(organizationData?.AvatarUrl))
            {
                throw new Exception("Avatar não encontrado.");
            }

            return organizationData.AvatarUrl;
        }


        public async Task<List<RepositoryModel>> GetOrganizationRepositoriesAsync(string organization)
        {
            var url = $"https://api.github.com/orgs/{organization}/repos?per_page=100";
            Console.WriteLine($"GET {url}");

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
                throw new HttpRequestException($"Erro ao buscar repositórios: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Resposta Repositórios: {content}");

            var repositories = JsonConvert.DeserializeObject<List<RepositoryModel>>(content);
            return repositories;
        }
    }
}
