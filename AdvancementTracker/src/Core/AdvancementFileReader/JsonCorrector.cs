using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class JsonCorrector
    {
        
        public static string Correct(List<string> advancements)
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
            var a = result.ToString();
            return result.ToString();
        }
    }
}
