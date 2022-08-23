public class Solution {
    public void MoveZeroes(int[] nums) {
       var j = 0;
       for(var i = 0; i < nums.Length; ++i)
       {
            if(nums[i] != 0)
            {
                var temp =nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
                
                ++j;
            }   
        }
    }
}