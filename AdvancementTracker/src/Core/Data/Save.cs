using AdvancementTracker.src.Core.Advancement;
using Newtonsoft.Json;
using System.IO;
namespace AdvancementTracker.src.Core.Data
{
    public class Save
    {
        public static void SaveAdvancments(Advancements advancements)
        {
            try
            {
                if (!Directory.Exists(Load.path + @"\AdvancementTracker"))
                {
                    Directory.CreateDirectory(Load.path + @"\AdvancementTracker");
                }
                var data = JsonConvert.SerializeObject(advancements, Formatting.Indented);
                File.WriteAllText(Load.path + @"\AdvancementTracker\save.json", data);
            }
            catch
            {
                throw;
            }
        }
    }
}
