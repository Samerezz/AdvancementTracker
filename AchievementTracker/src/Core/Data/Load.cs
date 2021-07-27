using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

using AdvancementTracker.src.Core.Advancement;
using AdvancementTracker.src.AdvancementWindow;
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
                    MainWindow.Advancements = advancements;
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                CreateAdvancements.Create(MainWindow.Advancements);
            }
            
        }
    }
}
