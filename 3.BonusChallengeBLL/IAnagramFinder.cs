using System.Collections.Generic;

namespace _3.BonusChallengeBLL
{
    public interface IAnagramFinder
    {
        List<List<string>> FindAnagrams(IEnumerable<string> words);
    }
}