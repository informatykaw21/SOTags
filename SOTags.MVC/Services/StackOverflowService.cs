using Newtonsoft.Json;
using SOTags.MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SOTags.MVC.Services
{
    public class StackOverflowService : IStackOverflowService
    {
        private readonly HttpClient _httpClient;

        public StackOverflowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TagInfo>> GetTopMostPopularTags(int count)
        {
            string url = string.Empty;

            if (count <= 100)
            {
                url = $"tags?page=1&pageSize={count}&order=desc&sort=popular&site=stackoverflow";
                var jsonResult = JsonConvert.DeserializeObject<TagInfoRoot>(await _httpClient.GetStringAsync(url));
                return jsonResult.Items;
            }
            else
            {
                List<TagInfo> tagsInfoList = new List<TagInfo>();
                int pageNumber = 1;
                do
                {
                    url = $"/tags?page={pageNumber}&pageSize=100&order=desc&sort=popular&site=stackoverflow";

                    tagsInfoList.AddRange(JsonConvert.DeserializeObject<TagInfoRoot>(await _httpClient.GetStringAsync(url)).Items);

                    count -= 100;
                    pageNumber++;
                } while (count > 0);

                return tagsInfoList;
            }
        }
    }
}