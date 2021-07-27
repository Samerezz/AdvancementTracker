using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AdvancementTracker.src.Core.Advancement;
namespace AdvancementTracker.src.AdvancementWindow
{
    class GetInfo
    {
        public static string Get(List<AdvancementObject> advancement)
        {
            double comp = 0;
            double total = 0;

            foreach (var obj in advancement)
            {
                total++;
                if (obj.IsCompleted)
                {
                    comp++;
                }
            }
            return $"{comp}/{total} | {Math.Round((comp / total) * 100)}%";
        }
    }
}
