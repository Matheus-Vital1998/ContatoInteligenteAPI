using Newtonsoft.Json;

namespace ContatoInteligenteAPI.Models
{
    public class OrganizationModel
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
