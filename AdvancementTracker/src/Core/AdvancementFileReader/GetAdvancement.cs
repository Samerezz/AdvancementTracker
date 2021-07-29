namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class GetAdvancement
    {
        /// <summary>
        /// Gets a spicific advancement from the minecraft advancement text.
        /// </summary>
        /// <param name="json">Minecraft advancement text.</param>
        /// <param name="stringNeeded">The part needed.</param>
        /// <param name="last">if this is the last part needed.</param>
        /// <returns>The part needed.</returns>
        public static string Get(string json, string stringNeeded, bool last = false)
        {
            string result;
            int index = json.IndexOf(stringNeeded);
            if (index == -1)
            {
                return string.Empty;
            }
            var index2 = GetLastIndex(json, index, last);
            result = json.Substring(index, index2);
            return result;
        }

        /// <summary>
        /// Gets the index of the last character needed.
        /// </summary>
        /// <param name="json">Minecraft advancement text.</param>
        /// <param name="startingIndex">The position to start from.</param>
        /// <param name="last">if this is the last part needed.</param>
        /// <returns>Index of the last character.</returns>
        static int GetLastIndex(string json, int startingIndex, bool last)
        {
            int openingBrackets = 1;
            int closingBrackets = 0;
            int i = 0;
            bool firstTime = true;
            while (openingBrackets != closingBrackets)
            {
                var nextChar = json[startingIndex + i];
                if (nextChar == '{')
                {
                    i++;
                    if (firstTime)
                    {
                        firstTime = false;
                        continue;
                    }
                    openingBrackets++;
                }
                else if (nextChar == '}')
                {
                    i++;
                    closingBrackets++;
                }
                else
                {
                    i++;
                }
            }
            if (!last)
            {
                i++;
            }
            return i;
        }
    }
}
