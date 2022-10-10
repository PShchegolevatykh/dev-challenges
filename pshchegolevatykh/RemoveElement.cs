public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var currentLength = nums.Length;
        // current shift from the end of the array
        var offset = 1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == val) {
                // see if we can replace it with the last item if it's not the same
                // shift the offset otherwise
                while (nums[nums.Length - offset] == val && offset < nums.Length) {
                    offset++;
                }
                // replace it with "current last"
                nums[i] = nums[nums.Length - offset];
                // increment the offset after replacement done
                if (offset < nums.Length) {
                    offset++;
                }
                // adjust current length
                currentLength--;
            }
        }

        return currentLength;
    }
}