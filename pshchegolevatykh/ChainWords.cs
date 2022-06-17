/* Circle of Chained Words

Two words can be 'chained' if the last character of the first word is the same as the first character of the second word.

Given a list of words, determine if there is a way to 'chain' all the words in a circle.

Example:
Input: { "eggs", "karat", "apple", "snack", "tuna"}
Output: true

Explanation:
The words in the order of { "apple", "eggs", "snack", "karat", "tuna" } creates a circle of chained words. */


// Assuming words are unique
// otherwise need to keep indexes to distinguish different words from existing repeated twice
bool CanWordsBeChained(string[] words)
{
    if (words.Length == 1)
    {
        return false; // assume one word cannot be chained with itself
    }

    // can be an array as well, but we need to store last index to insert properly
    // just additional variable
    var currentChain = new List<string>(words.Length);

    currentChain.Add(words.First()); // we can always start with the first word, it does not matter
    var lastChar = words.First().Last(); // remember last character of the first word to start comparison

    int i = 0;
    while (i < words.Length)
    {
        if (words[i].First() == lastChar
            && !currentChain.Contains(words[i])) // can implement "Contains" separately via array loop if necessary
        {
            currentChain.Add(words[i]);
            // check if we got full chain
            // 1. Length of the chain is the same as word array length
            // 2. Last symbol of last word in the chain equals first symbol of the very first word
            if (currentChain.Count == words.Length && words[i].Last() == words.First().First())
            {
                // we finished the chain, all good, exiting
                return true;
            }

            // chain got bigger, resetting counter to check again from the beggining
            lastChar = words[i].Last();
            i = 0;
            continue;
        }

        i++;
    }

    return false;
}


string[] words = new string[] { "apple", "karat", "tuna", "eggs", "snack" };

var canBeChanged = CanWordsBeChained(words);
Console.WriteLine(canBeChanged ? "Words can be chained" : "Words cannot be chained");
