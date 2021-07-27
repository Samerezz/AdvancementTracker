using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AdvancementTracker.src.Core.Advancement
{
    public static class CreateAdvancements
    {
        

        public static void Create(Advancements advancements)
        {
            AddItems(advancements.MonstersHunted, Properties.Resources.Monsters);
            AddItems(advancements.AbalancedDiet, Properties.Resources.Food);
            AddItems(advancements.AdventuringTime, Properties.Resources.Biomes);
            AddItems(advancements.TwoByTwo, Properties.Resources.Animals);
        }
        public static void AddItems(Advancement advancement, byte[] file)
        {
            var text = Encoding.UTF8.GetString(file);
            Root objectClass = JsonConvert.DeserializeObject<Root>(text);
            foreach (var item in objectClass.Objects)
            {
                advancement.Objects.Add(new AdvancementObject(item, false));
            }
        }
        public class Root
        {
            public List<string> Objects { get; set; }
        }
    }
}
