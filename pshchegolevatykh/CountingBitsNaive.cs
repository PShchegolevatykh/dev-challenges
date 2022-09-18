public class Solution {
    public int[] CountBits(int n) {
        var bits = new int[n+1];

        for (int i = 0; i < n+1; i++) {
            var currentDecimal = i;
            int bitsCount = 0;
            while (currentDecimal > 0) {
                int remainder = currentDecimal % 2;
                currentDecimal /= 2;
                if (remainder > 0) {
                    bitsCount++;
                }
            }
            bits[i] = bitsCount;
        }

        return bits;
    }
}