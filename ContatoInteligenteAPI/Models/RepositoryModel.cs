using Newtonsoft.Json;
using System;

namespace ContatoInteligenteAPI.Models
{
    public class RepositoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
