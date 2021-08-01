using SOTags.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOTags.MVC.Services
{
    public interface IStackOverflowService
    {
        public Task<List<TagInfo>> GetTopMostPopularTags(int count);
    }
}