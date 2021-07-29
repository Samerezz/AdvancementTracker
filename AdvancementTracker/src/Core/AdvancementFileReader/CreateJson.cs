using Newtonsoft.Json;
using System.Collections.Generic;

using AdvancementTracker.src.Core.Advancement;
namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class CreateJson
    {
        /// <summary>
        /// Creates the json neeeded from minecraft advancement file.
        /// </summary>
        /// <param name="data">Minecraft advancement file text.</param>
        /// <returns>All the needed Advancements.</returns>
        public static Advancements Create(string data)
        {

            string bredAllAnimals = GetAdvancement.Get(data, "\"minecraft:husbandry/bred_all_animals\": {");
            string adventuringTime = GetAdvancement.Get(data, "\"minecraft:adventure/adventuring_time\": {");
            string killAllMobs = GetAdvancement.Get(data, "\"minecraft:adventure/kill_all_mobs\": {");
            string balancedDiet = GetAdvancement.Get(data, "\"minecraft:husbandry/balanced_diet\": {");

            bredAllAnimals = Modifier.Modify(bredAllAnimals);
            adventuringTime = Modifier.Modify(adventuringTime);
            killAllMobs = Modifier.Modify(killAllMobs);
            balancedDiet = Modifier.Modify(balancedDiet);

            string json = JsonCombiner.Combine(new List<string> { bredAllAnimals, adventuringTime, killAllMobs, balancedDiet });

            var advancements = JsonConvert.DeserializeObject<Root>(json);

            return Checker.Check(advancements);

        }

    }
    public class Root
    {
        [JsonProperty("bred all animals")]
        public List<string> BredAllAnimals { get; set; }

        [JsonProperty("adventuring time")]
        public List<string> AdventuringTime { get; set; }

        [JsonProperty("kill all mobs")]
        public List<string> KillAllMobs { get; set; }

        [JsonProperty("balanced diet")]
        public List<string> BalancedDiet { get; set; }
    }
}
