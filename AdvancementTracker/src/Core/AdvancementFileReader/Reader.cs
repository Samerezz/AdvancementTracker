using System.IO;
using System.Text;
namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    public class Reader
    {
        /// <summary>
        /// Reads text from minecraft advancement file.
        /// </summary>
        /// <param name="stream">A stream to the file.</param>
        /// <returns>The text in the file.</returns>
        public static string Read(Stream stream)
        {
            string data;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer);
            data = Encoding.UTF8.GetString(buffer);
            stream.Dispose();
            return data;
        }
    }
}
