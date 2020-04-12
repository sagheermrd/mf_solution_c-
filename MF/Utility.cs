using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MF
{
    public class Utility
    {
        const string AlphaRegx = @"[^a-zA-Z'\s]+";
        private const int Increment = 1;
        private const int MaxItemsToReturn = 3;

        public string[] RepeatedWords(string sentence)
        {

            if (string.IsNullOrEmpty(sentence))
                return Array.Empty<string>();

            var cleanString = Regex.Replace(sentence.Trim(), AlphaRegx, string.Empty);
            var wordsArray = cleanString.ToLower().Split(' ').ToArray();
            var repeatedWords = new Dictionary<string, int>();

            for (var index = 0; index < wordsArray.Length; index++)
            {
                if (wordsArray[index] == string.Empty)
                    continue;

                if (repeatedWords.ContainsKey(wordsArray[index]))
                {
                    var wordCount = repeatedWords[wordsArray[index]];
                    repeatedWords[wordsArray[index]] = wordCount + Increment;
                }
                else
                    repeatedWords.Add(wordsArray[index], 1);
            }

            return repeatedWords.OrderByDescending(x => x.Value)
                                .ThenBy(x => x.Key)
                                .Select(x => x.Key)
                                .Take(MaxItemsToReturn)
                                .ToArray();
        }
    }
}
