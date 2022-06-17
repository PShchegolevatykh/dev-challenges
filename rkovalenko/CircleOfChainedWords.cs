namespace TestConsoleApp
{
    public static class CircleOfChainedWords
    {
        public static bool IsLooped(List<string> listOfWords)
        {
            if(!listOfWords.Any() || listOfWords.Count == 1)
            {
                return false;
            }

            var startingWordIndex = 0;
            var count = listOfWords.Count;
            for(var i = 1; i < count;)
            {
                // compare last char of one word and the first char of the second word
                if (listOfWords[startingWordIndex][^1] == listOfWords[i][0])
                {
                    if(i - startingWordIndex > 1)
                    {
                        var overlappingIndex = (startingWordIndex + 1) % count;
                        (listOfWords[i], listOfWords[overlappingIndex]) = (listOfWords[overlappingIndex], listOfWords[i]);
                    }

                    ++startingWordIndex;

                    i = startingWordIndex + 1;
                }
                else
                {
                    ++i;
                }
            }

            for(var i = 0; i < count; ++i)
            {
                var overlappingIndex = (i + 1) % count;
                if(listOfWords[i][^1] != listOfWords[overlappingIndex][0])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsLooped2(List<string> listOfWords)
        {

            if (!listOfWords.Any() || listOfWords.Count == 1)
            {
                return false;
            }

            var firstWord = listOfWords[0];

            //handle edge case here like a,a,a,a,a or a,b,a,a
            if(listOfWords.All(x => x.Length == 1))
            {
                return listOfWords.All(x => x == firstWord);
            }
            
            var lastChar = firstWord[^1];
            var hitCount = 0;
            var length = listOfWords.Count;
            
            // check if the words can be chained through here
            for(var i = 1; i < length; ++i)
            {
                var currentFirstChar = listOfWords[i][0];
                if (lastChar == currentFirstChar)
                {
                    ++hitCount;
                    lastChar = listOfWords[i][^1];
                   
                    i = -1;
                }

                if (hitCount == length)
                {
                    return true;
                }

            }

            return listOfWords[0][0] == listOfWords[^1][^1];
        }
    }
}
