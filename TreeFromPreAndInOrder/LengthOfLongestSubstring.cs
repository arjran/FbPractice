using System.Collections.Generic;

namespace FacebookPractice
{
    class LengthOfLongestSubstring
    {
        public int Run(string s)
        {
            var maxLength = 0;
            var letterList = new List<char>();

            foreach (char c in s)
            {
                if (letterList.Contains(c))
                {
                    var index = letterList.IndexOf(c);
                    letterList.RemoveRange(0, index + 1);
                }

                letterList.Add(c);

                if (maxLength < letterList.Count)
                {
                    maxLength = letterList.Count;
                }
            }

            return maxLength;
        }
    }
}
