using System;
using System.Collections.Generic;
using System.Linq;


namespace _3.BonusChallengeBLL
{
    public class AnagramFinder : IAnagramFinder
    {
        public List<List<string>> FindAnagrams(IEnumerable<string> words)
        {
            List<List<string>> result = new List<List<string>>();
            var cleanList = words.Select(s => s.ToLower().Replace(" ", "")).ToList();

            while (cleanList.Count > 0)
            {
                string firstWord = cleanList[0];
                var anagrams = new List<string> { firstWord };

                for (int i = 1; i < cleanList.Count; i++)
                {
                    if (AreAnagrams(firstWord, cleanList[i]))
                    {
                        anagrams.Add(cleanList[i]);
                        cleanList.RemoveAt(i);
                        i--; // Decrement i to account for the removed element
                    }
                }

                cleanList.RemoveAt(0);

                anagrams.Sort();
                result.Add(anagrams);
            }

            result.Sort((list1, list2) => string.Compare(list1[0], list2[0], StringComparison.OrdinalIgnoreCase));

            return result;
        }

        private bool AreAnagrams(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();

            Array.Sort(charArray1);
            Array.Sort(charArray2);

            return new string(charArray1).Equals(new string(charArray2), StringComparison.OrdinalIgnoreCase);
        }
    }
}