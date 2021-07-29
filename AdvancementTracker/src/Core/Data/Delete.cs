using System.IO;

namespace AdvancementTracker.src.Core.Data
{
    class Delete
    {
        /// <summary>
        /// Deletes save.json file in documents.
        /// </summary>
        public static void DeleteAdvancments()
        {
            if (File.Exists(Load.path + @"\AdvancementTracker\save.json"))
            {
                File.Delete(Load.path + @"\AdvancementTracker\save.json");
            }
        }
    }
}
