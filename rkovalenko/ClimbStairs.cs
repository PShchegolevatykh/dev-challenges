public class Solution {
    public int ClimbStairs(int n) {
        if(n <= 3)
        {
            return n;
        }
        return FibonacciSequence(n);
    }
    
    private int FibonacciSequence(int n, int num=2, int prevNum=1, int index=2)
    {
        //index=2 coz skipped first two nums of fibonacci sequence
        if(n == index)
        {
            return num;
        }
        
        var temp = num;
        num += prevNum;
        prevNum = temp;
        
        return FibonacciSequence(n, num, prevNum, ++index);
    }
}