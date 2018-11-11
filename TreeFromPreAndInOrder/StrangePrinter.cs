using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPractice
{
    class StrangePrinter
    {

        int maxSpacing = -1;
        public int Run(string s)
        {
            char longestSpacedLetter = ' ';
            var letterStartEnd = new Dictionary<char, Tuple<int, int>>();

            int index = 0;
            var currentTuple = new Tuple<int, int>(index, index);

            foreach (char c in s)
            {
                // Store the last occurance of all the letters found in the string           
                char res = updateDictionary(letterStartEnd, c, index);

                if (res != ' ')
                {
                    longestSpacedLetter = res;
                }
                index++;
            }

            int result = 0;
            while (letterStartEnd.Count > 0)
            {
                letterStartEnd.TryGetValue(longestSpacedLetter, out currentTuple);

                for (int i = currentTuple.Item1; i < currentTuple.Item2; i++)
                {
                    updateDictionary(letterStartEnd, s[i], i);
                }

                letterStartEnd.Remove(longestSpacedLetter);
                longestSpacedLetter = FindNextLongestChar(letterStartEnd);
                result++;
            }

            return result;
        }

        private char updateDictionary(Dictionary<char, Tuple<int, int>> letterStartEnd, char c, int index)
        {
            var currentTuple = new Tuple<int, int>(index, index);
            char longestSpacedLetter = ' ';
            // Store the last occurance of all the letters found in the string
            if (!letterStartEnd.TryGetValue(c, out currentTuple))
            {
                currentTuple = new Tuple<int, int>(index, index);
                letterStartEnd.Add(c, currentTuple);
            }
            else
            {
                letterStartEnd[c] = new Tuple<int, int>(currentTuple.Item1, index);
            }

            if (currentTuple.Item2 - currentTuple.Item1 > maxSpacing)
            {
                longestSpacedLetter = c;
                maxSpacing = currentTuple.Item2 - currentTuple.Item1;
            }


            return longestSpacedLetter;
        }

        private char FindNextLongestChar(Dictionary<char, Tuple<int, int>> dic)
        {
            var maxSpacing = -1;
            char resp = ' ';
            foreach (var item in dic)
            {
                if (item.Value.Item2 - item.Value.Item1 > maxSpacing)
                {
                    maxSpacing = item.Value.Item2 - item.Value.Item1;
                    resp = item.Key;
                }
            }

            return resp;
        }
    }
}
