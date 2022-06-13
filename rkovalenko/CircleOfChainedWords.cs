namespace TestConsoleApp
{
    public static class CircleOfChainedWords
    {
        public static bool IsLooped(IEnumerable<string> listOfWords)
        {
            var dict = new Dictionary<char, int>(listOfWords.Count() * 2);
            foreach (var word in listOfWords)
            {
                dict.AddOrIncrementValue(word[0]);
                dict.AddOrIncrementValue(word[^1]);

            }

            return dict.All(pair => pair.Value % 2 == 0);
        }

        private static void AddOrIncrementValue(this Dictionary<char, int> dictionary, char key)
        {
            if (dictionary.ContainsKey(key))
            {
                ++dictionary[key];
            }
            else
            {
                dictionary.Add(key, 1);
            }
        }
    }
}
