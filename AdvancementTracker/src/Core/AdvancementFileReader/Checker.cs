using AdvancementTracker.src.Core.Advancement;
namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class Checker
    {
        /// <summary>
        /// Determines the IsCompleted Property in every object.
        /// </summary>
        /// <param name="advancements">The advancements to compare with.</param>
        /// <returns>Advancements with the right IsCompleted property.</returns>
        public static Advancements Check(Root advancements)
        {
            Advancements result = new Advancements();
            CreateAdvancements.Create(result);
            if (advancements.BalancedDiet != null)
            {
                {
                    foreach (var obj1 in advancements.BalancedDiet)
                    {
                        foreach (var obj2 in result.ABalancedDiet.Objects)
                        {
                            if (obj1.ToLower().Equals(obj2.Name.ToLower().Replace("raw ", string.Empty)))
                            {
                                obj2.IsCompleted = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (advancements.AdventuringTime != null)
            {
                foreach (var obj1 in advancements.AdventuringTime)
                {
                    foreach (var obj2 in result.AdventuringTime.Objects)
                    {
                        if (obj1.ToLower().Equals(obj2.Name.ToLower()))
                        {
                            obj2.IsCompleted = true;
                            break;
                        }
                    }
                }
            }
            if (advancements.KillAllMobs != null)
            {
                foreach (var obj1 in advancements.KillAllMobs)
                {
                    foreach (var obj2 in result.MonstersHunted.Objects)
                    {
                        if (obj1.ToLower().Equals(obj2.Name.ToLower()))
                        {
                            obj2.IsCompleted = true;
                            break;
                        }
                    }
                }
            }
            if (advancements.BredAllAnimals != null)
            {
                foreach (var obj1 in advancements.BredAllAnimals)
                {
                    foreach (var obj2 in result.TwoByTwo.Objects)
                    {
                        if (obj1.ToLower().Equals(obj2.Name.ToLower()))
                        {
                            obj2.IsCompleted = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
