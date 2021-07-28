using System.IO;
using System.Text;
namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    public class Reader
    {
        static string Data { get; set; }
        public static void Read(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer);
            Data = Encoding.UTF8.GetString(buffer);
            stream.Dispose();
            CreateJson.Create(Data);
        }
    }
}
