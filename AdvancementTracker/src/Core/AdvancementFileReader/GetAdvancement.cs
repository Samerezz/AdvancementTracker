using System;

namespace AdvancementTracker.src.Core.AdvancementFileReader
{
    class GetAdvancement
    {
        public static string Get(string json, string stringNeeded, bool last = false)
        {
            string result;
            int index = 0;
            index = json.IndexOf(stringNeeded);
            if (index == -1)
            {
                return string.Empty;
            }
            var index2 =  GetLastIndex(json, index,last);

            result = json.Substring(index, index2);
            
            Console.WriteLine();
            return result;
        }
        static int GetLastIndex(string json,int startingIndex,bool last)
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
