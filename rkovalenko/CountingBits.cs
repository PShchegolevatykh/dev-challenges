public class Solution {
    public int[] CountBits(int n) {
        var byteArray = new int[n + 1];
        for(var i = 0; i <= n; ++i)
        {
            var byteString = Convert.ToString(i, 2);
            byteArray[i] = byteString.Count(x => x == '1');
        }
        
        return byteArray;
    }
}