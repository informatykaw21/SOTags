using Newtonsoft.Json;
using System.Collections.Generic;

namespace SOTags.MVC.Models
{
    public class TagInfoRoot
    {
        [JsonProperty("items")]
        public List<TagInfo> Items { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("quota_max")]
        public int QuotaMax { get; set; }

        [JsonProperty("quota_remaining")]
        public int QuotaRemaining { get; set; }
    }

    public class TagInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("is_required")]
        public bool IsRequired { get; set; }

        [JsonProperty("is_moderator_only")]
        public bool IsModeratorOnly { get; set; }

        [JsonProperty("has_synonyms")]
        public bool HasSynonyms { get; set; }
    }
}