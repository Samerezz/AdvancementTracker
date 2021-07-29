using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace AdvancementTracker.src.Core.Advancement
{
    public static class CreateAdvancements
    {
        /// <summary>
        /// Creates advancements from the json files in resources.
        /// </summary>
        /// <param name="advancements">The advancements.</param>
        public static void Create(Advancements advancements)
        {
            AddItems(advancements.MonstersHunted, Properties.Resources.Monsters);
            AddItems(advancements.ABalancedDiet, Properties.Resources.Food);
            AddItems(advancements.AdventuringTime, Properties.Resources.Biomes);
            AddItems(advancements.TwoByTwo, Properties.Resources.Animals);
        }

        /// <summary>
        /// Adds the advancement's items to the advancement.
        /// </summary>
        /// <param name="advancement">the advancement.</param>
        /// <param name="file">The file that contains the items.</param>
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
