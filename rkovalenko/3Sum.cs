public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        var hashSet = new HashSet<(int,int,int)>();

        for(int i = 0; i < nums.Length - 1; ++i)
        {
            var j = i + 1;
            var k = nums.Length - 1;

            while (k < nums.Length)
            {
                if(k <= j || k <= i)
                {
                    break;
                }

                var sum = nums[i] + nums[j] + nums[k];

                if (sum == 0)
                {
                    hashSet.Add((nums[i], nums[j], nums[k]));
                    --k;
                }
                if (sum < 0)
                {
                    ++j;
                }
                else if (sum > 0)
                {
                    --k;
                }
            }
        }

        var result = new List<IList<int>>(hashSet.Count);
        foreach (var triple in hashSet)
        {
            result.Add(new List<int> { triple.Item1, triple.Item2, triple.Item3 });
        }
        
        return result;
    }
}