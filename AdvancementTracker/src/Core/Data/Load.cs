using AdvancementTracker.src.AdvancementWindow;
using AdvancementTracker.src.Core.Advancement;
using Newtonsoft.Json;
using System;
using System.IO;
namespace AdvancementTracker.src.Core.Data
{
    class Load
    {
        public readonly static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// Loads advancements from save.json file in documents.
        /// </summary>
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
