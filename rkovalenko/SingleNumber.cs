public class Solution {
    public int SingleNumber(int[] nums) {
        Array.Sort(nums);

        if(nums.Length < 3)
        {
            return nums[0];
        }

        int? lastDifferentNum = null;
        var i = 1;

       do
       {
            if (nums[i] != nums[i - 1])
            {
                lastDifferentNum = nums[i - 1];
                break;
            }
           
            i += 2;
        }
        while (i <= nums.Length - 2);

        return  lastDifferentNum ??= nums[nums.Length - 1];
    }
}