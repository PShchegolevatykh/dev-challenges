public class Solution {
    public int RemoveElement(int[] nums, int val) {
        // k holds left part of array not containing `val`
            int k = nums.Length;
            for (int i = 0; i < k; i++)
            {
                if (nums[i] == val)
                {
                    ShiftLeft(nums, i);
                    k--;
                    i--;
                }
            }

            return k;
    }
    
     public void ShiftLeft(int[] nums, int startIndex)
        {
            if (nums.Length - 1 <= startIndex)
            {
                return;
            }

            // remeber shifted element
            var temp = nums[startIndex];
            for (int i = startIndex; i < nums.Length - 1; i++)
            {
                // shift elements one by one to the left
                nums[i] = nums[i + 1];
            }

            // put shifted el to the end of an array
            nums[nums.Length - 1] = temp;
        }
}