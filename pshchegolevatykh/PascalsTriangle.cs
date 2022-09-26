public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        int[][] triangle = new int[numRows][];

        if (numRows < 1) { // corner case and exception handling
            return triangle;
        }
        
        // r = current row pointer
        // c = current column pointer
        for (int r = 0; r < numRows; r++) { // for each row
            // this is how size relates to row index
            // e.g. for row = 2 there's 3 elements
            triangle[r] = new int[r+1]; 
            for (int c = 0; c < r+1; c++) { // for each column
                if (c == 0 || c == r) { // first and last elements are always 1
                    triangle[r][c] = 1;
                } else { // it should be sum of adjacent (current and previous) elements of previous(r-1) row
                    triangle[r][c] = triangle[r-1][c] + triangle[r-1][c-1];
                }
            }
        }

        return triangle;
    }
}