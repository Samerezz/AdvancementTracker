using System.Text;

namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class Modifier
    {
        /// <summary>
        /// Modifies alot of things in minecraft's advancements file 
        /// </summary>
        /// <param name="json">the json text to modify.</param>
        /// <returns>The modified string.</returns>
        public static string Modify(string json) {
            StringBuilder str = new StringBuilder();
            foreach (var character in json)
            {
                if (char.IsDigit(character) || character == '-' || character == '+')
                {
                    continue;
                }
                str.Append(character);
            }
            str = str.Replace(" :: ", string.Empty)
                .Replace("\"\"", string.Empty).Replace("minecraft:", string.Empty)
                .Replace("adventure/", string.Empty).Replace("husbandry/", string.Empty)
                .Replace("\"criteria\": {", string.Empty).Replace("\"done\": false", string.Empty)
                .Replace("\"done\": true", string.Empty).Replace("},", "]")
                .Replace(":", string.Empty).Replace('{', '[').Replace('_', ' ');
            
            bool closed = true;
            StringBuilder str2 = new StringBuilder();
            foreach (var character in str.ToString())
            {
                if (character == '[')
                {
                    str2.Append(":"+character);
                    closed = false;
                }else if(character == ']' && !closed)
                {
                    closed = true;
                    if (str2.Length == str.Length - 7)
                    {
                        str2.Append(character);
                        
                        continue;
                    }
                    str2.Append(character + ",");
                }
                else if( character ==']' && closed)
                {
                    continue;
                }
                else
                {
                    str2.Append(character);
                }
            }
            json = str2.ToString();
            return json;
        }
    }
}
