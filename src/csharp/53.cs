// Leetcode Problem : Maximum Subarray
// https://leetcode.com/problems/maximum-subarray/
// Related Topics : Array, Divide and Conquer, Dynamic Programming

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            nums[i] = Math.Max(nums[i], nums[i] + nums[i - 1]);
            if (max < nums[i]) max = nums[i];
        }
        
        return max;
    }
}