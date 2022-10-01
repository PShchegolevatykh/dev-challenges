public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var i = 0;
        var j = nums.Length - 1;
        while (i <= j)
        {
           if (nums[j] == val)
           {
              --j;
           }
           else if (nums[i] == val)
           {
              (nums[i], nums[j]) = (nums[j], nums[i]);
           }
           else
           {
              ++i;
           }
        }
        
        return ++j;
    }
}