using AdvancementTracker.src.Core.Advancement;
using AdvancementTracker.src.Core.Data;
namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class Checker
    {
        public static void Check(Root advancements1)
        {
            Advancements result = new Advancements();
            CreateAdvancements.Create(result);
            if (advancements1.BalancedDiet != null)
            {
                {
                    foreach (var obj1 in advancements1.BalancedDiet)
                    {
                        foreach (var obj2 in result.AbalancedDiet.Objects)
                        {
                            if (obj1.ToLower().Equals(obj2.Name.ToLower().Replace("raw ",string.Empty)))
                            {
                                obj2.IsCompleted = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (advancements1.AdventuringTime != null)
            {
                foreach (var obj1 in advancements1.AdventuringTime)
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
            if (advancements1.KillAllMobs != null)
            {
                foreach (var obj1 in advancements1.KillAllMobs)
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
            if (advancements1.BredAllAnimals != null)
            {
                foreach (var obj1 in advancements1.BredAllAnimals)
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
            Save.SaveAdvancments(result);
            Load.LoadAdvancments();
        }
    }
}
