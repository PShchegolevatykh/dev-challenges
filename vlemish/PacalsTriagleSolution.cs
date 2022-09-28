public class Solution {
     public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> generatedPascalsTriangles = new List<IList<int>>(numRows);
        List<int> lastTriangle = null;
        for (int row = 1; row <= numRows; row++)
        {
            lastTriangle = FillPascalsTriangle(lastTriangle, row);
            generatedPascalsTriangles.Add(lastTriangle);
        }

        return generatedPascalsTriangles;
    }

    private List<int> FillPascalsTriangle(IList<int> triangle, int numRows)
    {
        var pascalTriangle = new List<int>(numRows + 1);
        // add first element
        pascalTriangle.Add(1);

        // calculate middle
        if (numRows > 2 && triangle is not null)
        {
            // calculate
            for (int i = 0; i < triangle.Count - 1; i++)
            {
                var sum = triangle[i] + triangle[i + 1];
                pascalTriangle.Add(sum);
            }
        }

        //add last element
        if (numRows > 1)
        {
            pascalTriangle.Add(1);
        }

        return pascalTriangle;
    }
}