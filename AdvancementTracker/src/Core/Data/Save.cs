using AdvancementTracker.src.Core.Advancement;
using Newtonsoft.Json;
using System;
using System.IO;
namespace AdvancementTracker.src.Core.Data
{
    public class Save
    {
        /// <summary>
        /// Saves advancements to save.json file in documents.
        /// </summary>
        /// <param name="advancements">The advancements to save.</param>
        public static void SaveAdvancments(Advancements advancements)
        {
            if (!Directory.Exists(Load.path + @"\AdvancementTracker"))
            {
                Directory.CreateDirectory(Load.path + @"\AdvancementTracker");
            }
            var data = JsonConvert.SerializeObject(advancements, Formatting.Indented);
            File.WriteAllText(Load.path + @"\AdvancementTracker\save.json", data);
        }
    }
}
