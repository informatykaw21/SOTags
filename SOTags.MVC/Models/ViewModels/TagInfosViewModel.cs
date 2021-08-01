using System;
using System.Collections.Generic;
using System.Linq;

namespace SOTags.MVC.Models.ViewModels
{
    public class TagInfosViewModel
    {
        public TagInfosViewModel(List<TagInfo> tagInfos)
        {
            TagInfos = tagInfos;
            TagsPercentages = CalculatePercentages();
        }

        public List<TagInfo> TagInfos { get; set; }
        public Dictionary<string, float> TagsPercentages { get; private set; }

        private Dictionary<string, float> CalculatePercentages()
        {
            Dictionary<string, float> dict = new Dictionary<string, float>();

            // relative point to calculate percentage from - SUM
            var tagsSum = TagInfos.Select(t => t.Count).Sum();

            foreach (var tag in TagInfos)
            {
                var thisTagPercentageCountValue = tag.Count / (float)tagsSum * 100;
                dict.Add(tag.Name, (float)Math.Round(thisTagPercentageCountValue, 6));
            }
            return dict;
        }
    }
}