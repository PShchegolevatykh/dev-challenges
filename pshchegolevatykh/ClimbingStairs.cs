public class Solution {
    private Dictionary<int,int> preCalculatedMemo = new Dictionary<int, int>();
    
    public int ClimbStairs(int n) {
        if (n <= 1) {
            return 1;
        }
    
        if (preCalculatedMemo.ContainsKey(n)) {
            return preCalculatedMemo[n];
        } else {
            preCalculatedMemo[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            return preCalculatedMemo[n];
        }
    }
}