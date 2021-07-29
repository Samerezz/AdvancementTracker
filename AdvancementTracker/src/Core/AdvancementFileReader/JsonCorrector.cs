using System.Collections.Generic;
using System.Text;

namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class JsonCombiner
    {
        /// <summary>
        /// Combines all advancements together and corrects some things.
        /// </summary>
        /// <param name="advancements">All the advancements</param>
        /// <returns>All the advancements Combined</returns>
        public static string Combine(List<string> advancements)
        {
            StringBuilder result = new StringBuilder();
            result.Append('{');
            foreach (var advancement in advancements)
            {
                result.Append(advancement);
            }
            result[result.Length - 1] = ' ';
            result[result.ToString().LastIndexOf(',')] = ' ';
            result.Append('}');
            return result.ToString();
        }
    }
}
