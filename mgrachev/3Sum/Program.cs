/*
3Sum

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

------------

Solution:

Brute-force solution is to operate three pointers (three indices) and thus perform 3 loop iterations for the given array.
Though more optimal solution is to use two loops and instead of third loop we will use memoization of existing elements in a hashset. 
For each nums[i] and nums[j] we will check if there is an existing element in between these two pointers, 
such that the sum of the three is zero.

Uniqueness of results will be proved by having a hashset of sorted indices (basically, tuples of three).
.
*/
IList<IList<int>> ThreeSum(int[] nums) 
{
    if (nums==null || nums.Length<3) throw new ArgumentException(nameof(nums));

    var result = new List<IList<int>>();
    var htResults = new HashSet<Tuple<int,int,int>>();

    // Existing numbers between nums[i] and nums[j]
    for(int i=0; i<nums.Length-2; i++)
    {
        int target = 0 - nums[i];
        var htExistingNumbers = new HashSet<int>();
        
        for(int j=i+1; j<nums.Length; j++)
        {
            if(htExistingNumbers.Contains(target-nums[j]))
            {
                var array = new[]{nums[i], target-nums[j], nums[j]};
                Array.Sort(array);
                var resultTuple = new Tuple<int, int, int>(array[0], array[1], array[2]);
                if (!htResults.Contains(resultTuple))
                {
                    htResults.Add(resultTuple);
                    result.Add(array);
                }
            }
            else
            {
                htExistingNumbers.Add(nums[j]);
            }
        }
    }
    return result;    
}


int [] nums = new[] {-1,0,1,2,-1,-4};

var result = ThreeSum(nums);

foreach(var arr in result)
{
    Console.Write($"{arr[0]} {arr[1]} {arr[2]}\n");
}


