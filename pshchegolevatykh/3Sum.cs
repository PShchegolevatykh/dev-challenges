using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static bool IsDuplicateForSortedOnly(IList<int> tripletA, IList<int> tripletB)
        {
            for (int i = 0; i < tripletA.Count; i++)
            {
                if (tripletA[i] != tripletB[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Contains(IList<IList<int>> tripletList, IList<int> targetTriplet)
        {
            foreach (var triplet in tripletList)
            {
                if (IsDuplicateForSortedOnly(triplet, targetTriplet))
                {
                    return true;
                }
            }

            return false;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            
            for (int i = 0; i < nums.Length; i++) // each one
            {
                for (int j = 0; j < nums.Length; j++) // compared with each another one
                {
                    for (int k = 0; k < nums.Length; k++) // compared with each third one
                    {
                        // not the same element
                        if (i != j && i != k && j != k)
                        {
                            // checking sum
                            if (nums[i] + nums[j] + nums[k] == 0)
                            {
                                var tripletCandidate = new List<int> { nums[i], nums[j], nums[k] };

                                tripletCandidate.Sort(); // need for proper duplicate comparison
                              
                                if (!Contains(result, tripletCandidate))
                                {
                                    result.Add(tripletCandidate);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var input = new List<int> { 9, 14, 0, -8, 10, 0, 2, 9, -8, 13, -3, 1, 10, -13, 4, 3, -3, -11, 8, -13, -4, -6, 5, -10, -14, 0, 3, -9, -9, -7, -11, 8, -8, -4, -15, 9, 11, 3, 3, -11, -7, 7, 5, -12, 1, -14, -1, 13, -9, -8, 7, 2, -6, -11, -1, -5, -4, -13, -7, 2, -13, -2, -5, -6, 9, -12, 10, -2, -2, -10, 2, 6, 4, 14, 2, -10, -15, -14, 10, -9, -15, -6, 0, -6, -2, 14, -3, 9, 8, -3, -12, 10, 2, -9, 11, -3, -6, -2, 10, 7, 3, -11, -10, -8, -12, -1 }.ToArray();
            var output = ThreeSum(input); 
        }
    }
}
