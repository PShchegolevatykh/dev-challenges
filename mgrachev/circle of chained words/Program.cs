﻿/*
Two words can be 'chained' if the last character of the first word is the same as the first character of the second word.

Given a list of words, determine if there is a way to 'chain' all the words in a circle.

Example:
Input: ['eggs', 'karat', 'apple', 'snack', 'tuna']
Output: True
Explanation:
The words in the order of ['apple', 'eggs', 'snack', 'karat', 'tuna'] creates a circle of chained words.
*/


/*

Solution

- can start from any word in the list, each word is a chance to build a full circle
- if any word does not have any other suitable next word from the list, there is no chance to build a circle 
- "the circle" is an array of words 
    - where each word's last char is the same as next word's first char, except for last word in the array
- once the circle is built, the number of words used in chain equals total number of word, 
  and the last word's last char matches the first word's first char), we can finish our program

- regarding storage:
  we need to store word's indices in order ("circle builder array" of N integers)

- algo
    - will have 
    - must have "current word" pointer
    - must have "potentially suitable word" pointer
    - must have "used words" list (or dictionary)
    - must have "circle builder" list where suitable words are placed subsequently maintaining chained order

    - will start with the first word in list
    - when "suitable" next word is found, it can be marked as "used" and placed into "circle builder" list 
    - "suitable" words must be looked starting from the beginning of word list, excluding "current word" and "used" words,
        until there are no more words available
         - if a word is "suitable": 
                * it is added to "used words" list/dict, 
                * it is added to "circle builder array", 
                * the "current word" pointer is increased until the next unused word or until there are no unused words left
         - if a word is not "suitable": 
                increase "potential suitable word" pointer
    
    - if there is no suitable word found, then the "words circle" is not possible

    - processing is over when the length of "the circle builder" is equal to the length of list
        - check the "circle builder array": 
          the last word's last char should be the same as the first word's first char. 
          if it's true, the "words circle" is built, otherwise it's not possible. 
 
- optimizations
    - can store "used words" in a hashtable (Dictionary) 
        * e.g. word is a key in Dictionary<string,bool>, and value means if it is "used" in circle
        * or index of word is a key in Dictionary<int, bool>, and value means if it is "used" in circle
        * this will give us O(1) lookup time for each word 

    - instead of traversing all the words in a list to find a "suitable", can store "potentially suitable" words 
        in a separate list, deleting used ones,  so the number of checks will be decreased - performance gain 

    - can use indices instead of strings for "used words dictionary", "circle builder", it will also allow duplicate words 

- Time complexity: O(N*2)
  Can improve time by introducing extra list for "not used words" 
*/

var testCases = new []
{
    new [] {"eggs", "karat", "apple", "snack", "tuna"},
    new [] {"eggs", "karat", "apple", "snack", "tuna", "sage", "ears"},
    new [] {"axb", "bxc", "cxd", "dxa"},
    new [] {"bxc", "axb", "dxa", "cxd"},
    new [] {"axb", "bxc", "cxd", "dxe"},
    new [] {"aba", "aca"},
    new [] {"aba"}
};

foreach (var testWords in testCases)
{
    foreach(var word in testWords)
    {
        Console.Write("{0}{1}",word, word==testWords[testWords.Length-1]?". ":", ");
    }
    Console.WriteLine($"Result: {CanChainWords(testWords)}");
}

bool CanChainWords(string[] words)
{
        if (words == null || words.Length < 2)
        {
                // Should have more than one word in words list parameter
                return false;
        }

        int currentWordIx = 0;

        var usedDictionary = new Dictionary<string, bool>(words.Length);
        var circleBuilder = new List<string>();

        for(int i=0; i<words.Length; i++)
        {
                usedDictionary.Add(words[i], false);
        }
 
        circleBuilder.Add(words[currentWordIx]);
        usedDictionary[words[currentWordIx]] = true;

        var doContinue = true;
        while (doContinue) 
        {
                doContinue = circleBuilder.Count < words.Length;
                var currentWord = words[currentWordIx];

                if(doContinue) // if circle builder is full, no need to find the suitable "next"
                {
                        // try to find suitable "next" word by traversing the dictionary and also checking "used" flag
                        
                        bool found = false;

                        for(int potentiallySuitableIx=0; potentiallySuitableIx < words.Length; potentiallySuitableIx++)
                        {
                                var potentiallySuitableWord = words[potentiallySuitableIx];
                                bool used = usedDictionary[potentiallySuitableWord];

                                if (!used && currentWord[currentWord.Length-1]==potentiallySuitableWord[0])
                                {
                                        found = true;
                                        usedDictionary[potentiallySuitableWord] = true;
                                        circleBuilder.Add(potentiallySuitableWord);
                                        currentWordIx = potentiallySuitableIx;                                                

                                        break;
                                }
                        }
                        if (!found)
                        {
                                return false;
                        }
                }
                
        }
        var lastWord = circleBuilder[circleBuilder.Count-1];
        var firstWord = circleBuilder[0];
        return lastWord[lastWord.Length-1] == firstWord[0];
}