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

Tuple<int, int, int> MakeSortedTuple(IList<int> nums)
{
    var numbers = nums.ToArray();
    Array.Sort(numbers);
    return new Tuple<int, int, int>(numbers[0], numbers[1], numbers[2]);
}

IList<IList<int>> ThreeSum(int[] nums) {

    int i=0; int j=1; int k=2;
    var htIndicesSum = new Dictionary<Tuple<int,int,int>, bool>();
    var result = new List<IList<int>>();    

    for (i=0; i<nums.Length; i++)
    {
        for(j=1; j<nums.Length; j++)
        {
            for(k=2; k<nums.Length; k++)
            {                
                if (i!=j && i!=k && k!=j)
                {
                    var sortedTuple = MakeSortedTuple(new[] { nums[i], nums[j], nums[k] });
                    if(!htIndicesSum.ContainsKey(sortedTuple))
                    {
                        htIndicesSum[sortedTuple] = true;
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            result.Add(new [] { nums[i], nums[j], nums[k]});
                        }
                    }
                }                
            }
        }
    }
    return result;
}

int [] nums = new[] {-2,0,1,1,2};

var result = ThreeSum(nums);

foreach(var arr in result)
{
    Console.Write($"{arr[0]} {arr[1]} {arr[2]}\n");
}

