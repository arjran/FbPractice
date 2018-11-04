using System;

namespace FacebookPractice
{
    class FindMedianSortedArrays
    {
        public double Run(int[] nums1, int[] nums2)
        {
            var isSingleMedian = (nums1.Length + nums2.Length) % 2 != 0;

            if (nums1.Length == 0)
            {
                return isSingleMedian
                    ? nums2[(nums2.Length) / 2]
                    : (double)(nums2[nums2.Length / 2 - 1] + nums2[nums2.Length / 2]) / 2;
            }
            if (nums2.Length == 0)
            {
                return isSingleMedian
                    ? nums1[nums1.Length / 2]
                    : (double)(nums1[nums1.Length / 2 - 1] + nums1[nums1.Length / 2]) / 2;
            }

            // An edge case this solution will not handle, so we handle this here.
            if (nums1.Length == 1 && nums2.Length == 1)
            {
                return (double)(nums1[0] + nums2[0]) / 2;
            }

            // The length we need for the left partition
            var partitionLength = (nums1.Length + nums2.Length + 1) / 2;

            // Make the smaller array nums1
            if (nums2.Length < nums1.Length)
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            // Divide and conquer start and end values on nums1 array.
            int start = 0;
            int end = nums1.Length - 1;

            // count1 + count2 should equal partitionLength.
            var count1 = 0;
            var count2 = 0;

            // index1 and index2 mark the position in the arrays to get count number of elements.
            var index1 = 0;
            var index2 = 0;

            while (true)
            {
                count1 = ((end - start) / 2) + 1;
                count2 = partitionLength - count1;

                index1 = count1 + start - 1;
                index2 = count2 - 1;

                if (start == end)
                {
                    break;
                }

                // Condition met where equals halves present around the indices, return result.
                if (nums1[index1] <= nums2[index2 + 1]
                    && nums2[index2] <= nums1[index1 + 1])
                {
                    return isSingleMedian
                        ? Math.Max(nums1[index1], nums2[index2])
                        : (double)(Math.Max(nums1[index1], nums2[index2])
                            + Math.Min(nums1[index1 + 1], nums2[index2 + 1])) / 2;
                }
                // Else continue divide and conquer.
                else if (nums1[index1 + 1] < nums2[index2])
                {
                    start = index1 + 1;
                }
                else
                {
                    end = index1 - 1;
                }
            }

            // Edge cases where result wasn't found until only one element exists in array1.

            if (isSingleMedian)
            {
                return (nums1[index1] > nums2[index2 + 1])
                    ? nums2[index2 + 1]
                    : Math.Max(nums1[index1], nums2[index2]);
            }
            else
            {
                var median1 = 0;
                var median2 = 0;

                if (nums1[index1] < nums2[index2 + 1])
                {
                    median1 = Math.Max(nums1[index1], nums2[index2]);
                    median2 = nums2[index2 + 1];
                }
                else
                {
                    median1 = nums1[index1];
                    median2 = nums2[index2 + 1];
                }

                return (double)(median1 + median2) / 2;
            }
        }
    }
}