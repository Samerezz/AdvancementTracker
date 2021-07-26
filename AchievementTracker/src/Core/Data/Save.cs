using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

using AdvancementTracker.src.Core.Advancement;
namespace AdvancementTracker.src.Core.Data
{
    public class Save
    {
        public static void SaveAdvancments()
        {
            try
            {
                if (!Directory.Exists(Load.path + @"\AdvancementTracker"))
                {
                    Directory.CreateDirectory(Load.path + @"\AdvancementTracker");
                }
                var data = JsonConvert.SerializeObject(CreateAdvancements.Advancements,Formatting.Indented);
                File.WriteAllText(Load.path + @"\AdvancementTracker\save.json", data);
            }
            catch
            {
                throw;
            }
        }
    }
}
