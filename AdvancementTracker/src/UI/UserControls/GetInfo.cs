using AdvancementTracker.src.Core.Advancement;
using System;
using System.Collections.Generic;
namespace AdvancementTracker.src.UI.UserControls
{
    class GetInfo
    {
        /// <summary>
        /// Gets some useful info from the advancement.
        /// </summary>
        /// <param name="advancement">The Advancement</param>
        /// <returns>percentage of how many items are done in an advancement.</returns>
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
