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
    class Load
    {
        public readonly static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static void LoadAdvancments()
        {
            if (File.Exists(path + @"\AdvancementTracker\save.json"))
            {
                try
                {
                    Directory.CreateDirectory(path + @"\AdvancementTracker");

                    var text = File.ReadAllText(path + @"\AdvancementTracker\save.json");
                    Advancements advancements = JsonConvert.DeserializeObject<Advancements>(text);
                    CreateAdvancements.Advancements = advancements;
                }
                catch
                {
                    //CreateAdvancements.Advancements = new Advancements();
                    throw;
                }
            }
            else
            {
                CreateAdvancements.Create();
            }
            
        }
    }
}
