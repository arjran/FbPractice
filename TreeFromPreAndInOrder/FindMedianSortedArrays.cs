using System;

namespace FacebookPractice
{
    class FindMedianSortedArrays
    {
        public double Run(int[] nums1, int[] nums2)
        {
            var isOdd = (nums1.Length + nums2.Length) % 2 != 0;

            // Make the smaller array nums1
            if (nums2.Length < nums1.Length)
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }
            if (nums1.Length == 0)
            {
                return isOdd
                    ? nums2[(nums2.Length) / 2]
                    : (nums2[nums2.Length / 2 - 1] + nums2[nums2.Length / 2]) / 2.0;
            }

            // The length we need for the left partition
            var mid = (nums1.Length + nums2.Length + 1) / 2;

            var iMin = 0;
            var iMax = nums1.Length;

            while (iMin <= iMax)
            {
                var i = iMin + (iMax - iMin) / 2;
                var j = mid - i;

                if (j > 0 && i < nums1.Length && nums1[i] < nums2[j - 1])
                {
                    iMin = i + 1;
                }
                else if (i > 0 && j < nums2.Length && nums1[i - 1] > nums2[j])
                {
                    iMax = i - 1;
                }
                else
                {
                    var maxLeft = 0;
                    var minRight = 0;

                    if (i == 0)
                    {
                        maxLeft = nums2[j - 1];
                    }
                    else if (j == 0)
                    {
                        maxLeft = nums1[i - 1];
                    }
                    else
                    {
                        maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }

                    if (isOdd)
                    {
                        return maxLeft;
                    }

                    if (i == nums1.Length)
                    {
                        minRight = nums2[j];
                    }
                    else if (j == nums2.Length)
                    {
                        minRight = nums1[i];
                    }
                    else
                    {
                        minRight = Math.Min(nums1[i], nums2[j]);
                    }

                    return (maxLeft + minRight) / 2.0;
                }
            }

            return 0;
        }
    }
}