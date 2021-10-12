// input: -2,1,-3,4,-1,2,1,-5,4
// output: 6
// Explanation: [4,-1,2,1] has the largest sum = 6.

public int MaxSubArray(int[] nums) {
    int dp = nums[0];
    int max = dp;
    
    for(int i = 1; i < nums.Length; i++) {
        dp = nums[i] + Math.Max(dp, 0);
        max = Math.Max(max, dp);
    }
    
    return max;
}