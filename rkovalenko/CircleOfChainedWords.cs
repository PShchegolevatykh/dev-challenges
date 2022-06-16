namespace TestConsoleApp
{
    public static class CircleOfChainedWords
    {
        public static bool IsLooped(List<string> listOfWords)
        {
            if(!listOfWords.Any())
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
    }
}
