public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var list = new List<IList<int>>(numRows);

        var rowCount = 1;
        var prevListIndex = 0;
        for (var i = 0; i < numRows; ++i)
        {
            var rowList = new List<int>(rowCount);
            for (var j = 0; j < rowCount; ++j)
            {
                if (j == 0 || j == rowCount - 1)
                {
                    rowList.Add(1);
                    continue;
                }

                var firstNum = list[i - 1][prevListIndex++];
                var secondNum = list[i - 1][prevListIndex];
                rowList.Add( firstNum + secondNum );
            }
            ++rowCount;
            prevListIndex = 0;
            list.Add(rowList);
        }

        return list;
    }
}
