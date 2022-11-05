public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var i = m - 1;
        var j = n - 1;
        var index = m + n - 1;
        
        while (j >= 0)
        {
            nums1[index--] = i >= 0 && nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
        }
    }
}
