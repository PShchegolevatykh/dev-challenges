/*
3Sum

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

------------

Solution:

We need to operate three pointers (three indices) for the given array.
We will iterate through the numbers in array with three "for" loops starting with 0 for i, 1 for j, 2 for k.
We can use Dictionary to store "sorted" tuple of three ints with boolean value meaning the sum for these indices is 0 (O(1) add time).
Each time before calculation we can check in the dict if such indices were already used previously (O(1) key lookup time), thus we get rid of repetitions.
If indices were not used previously, add them to the dictionary.
If the condition is met (indices are not equal and the sum of three numbers is 0), add tuple to the result list.
*/

using System.Linq;

bool IsUsed(Dictionary<Tuple<int,int,int>, bool> dictIndicesSum, int num1, int num2, int num3)
{    
    var sortedTuple = MakeSortedTuple(num1, num2, num3);
    return dictIndicesSum.ContainsKey(sortedTuple);
}

Tuple<int, int, int> MakeSortedTuple(int num1, int num2, int num3)
{
    var indices = new int[] { num1, num2, num3 };
    Array.Sort(indices);
    return new Tuple<int, int, int>(indices[0], indices[1], indices[2]);
}

IList<Tuple<int,int,int>> ThreeSum(int[] nums) {

    int i=0; int j=1; int k=2;
    var dictIndicesSum = new Dictionary<Tuple<int,int,int>, bool>();
    var result = new List<Tuple<int, int, int>>();    

    for (i=0; i<nums.Length; i++)
    {
        for(j=1; j<nums.Length; j++)
        {
            for(k=2; k<nums.Length; k++)
            {
                if(!IsUsed(dictIndicesSum, i, j, k))
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    var tuple = MakeSortedTuple(i,j,k);
                    var condition = i!=j && i!=k && k!=j && sum == 0;
                    dictIndicesSum[tuple] = condition;
                    if (condition)
                    {
                        result.Add(tuple);
                    } 
                }
            }
        }
    }
    return result;
}

int [] nums = new[] { -1, 0, 1, 2, -1, -4};

var result = ThreeSum(nums);

foreach(var triplet in result)
{
    Console.Write($"{triplet.Item1} {triplet.Item2} {triplet.Item3}\n");
}

