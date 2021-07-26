using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class CreateJson
    {
        public static void Create(string data)
        {
            string bredAllAnimals = GetAdvancement.Get(data, "\"minecraft:husbandry/bred_all_animals\": {");
            string adventuringTime = GetAdvancement.Get(data, "\"minecraft:adventure/adventuring_time\": {");
            string killAllMobs = GetAdvancement.Get(data, "\"minecraft:adventure/kill_all_mobs\": {");
            string balancedDiet = GetAdvancement.Get(data, "\"minecraft:husbandry/balanced_diet\": {");

            bredAllAnimals = Replacer.Replace(bredAllAnimals);
            adventuringTime = Replacer.Replace(adventuringTime);
            killAllMobs = Replacer.Replace(killAllMobs);
            balancedDiet = Replacer.Replace(balancedDiet);
            string json = JsonCorrector.Correct(new List<string> { bredAllAnimals, adventuringTime, killAllMobs, balancedDiet });
            var advancements1 = JsonConvert.DeserializeObject<Root>(json);
            Checker.Check(advancements1);
            
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
