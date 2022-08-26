public class Solution {
    public void MoveZeroes(int[] nums) {
       // solution is very similar to bubble sort
       // if you look at the sequence closely
       // [0,1,0,3,12] -> [1,0,3,0,12] -> [1,3,0,12,0] -> [1,3,12,0,0]
       // you can notice that zeroes bubble up and up after each swap
       // so we have exactly the same algorithm, only instead of temp variable for swap use zero
       for (int i = 0; i < nums.Length; i++) {
           for (int j = i+1; j < nums.Length; j++) {
               if (nums[i] == 0) {
                   nums[i] = nums[j];
                   nums[j] = 0;
               }
           }
       } 
    }
}