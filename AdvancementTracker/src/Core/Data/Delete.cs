using System.IO;

namespace AdvancementTracker.src.Core.Data
{
    class Delete
    {
       public static void DeleteAdvancments()
        {
            if (File.Exists(Load.path + @"\AdvancementTracker\save.json"))
            {
                File.Delete(Load.path + @"\AdvancementTracker\save.json");
            }
        }
    }
}
