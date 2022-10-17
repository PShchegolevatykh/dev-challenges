namespace DevChallengesSolution;

public class MoveZeroesSolution
{
    // Traverse an array looking for zeroes
    // For every found zero shift elements in the array to left starting from next element to zero and finishing with last known zero on the right
    // *keep count of number of shifts, it'll help escaping doing useless operations
    public void MoveZeroes(int[] nums)
    {
        if (nums.Length < 2)
        {
            return;
        }
        
        int numberOfShifts = 0;
        int i = 0;
        while ((i + numberOfShifts) < nums.Length)
        {
            if (nums[i] == 0)
            {
                ShiftLeft(nums, i, nums.Length - numberOfShifts);
                numberOfShifts++;
            }
            else
            {
                i++;
            }
        }
    }

    private void ShiftLeft(int[] nums, int indexFrom, int indexTo)
    {
        for (int i = indexFrom; i < indexTo - 1; i++)
        {
            nums[i] = nums[i + 1];
        }

        nums[indexTo - 1] = 0;
    }
}