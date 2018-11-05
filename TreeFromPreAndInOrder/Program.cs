using FacebookPractice.LeetCode;
using System;
using System.Collections.Generic;

namespace FacebookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //BuildTreeFromPreAndInOrder();
            //AddTwoLLNumbers();
            //FindMedianSortedArrays();
            //LengthOfLongestSubstring();

            MergeKSortedLL();
            Console.ReadLine();
        }

        private static void MergeKSortedLL()
        {
            var list1 = new ListNode(1)
            {
            };

            //var list2 = new ListNode(-3)
            //{
            //    next = new ListNode(1)
            //    {
            //        next = new ListNode(4)
            //    }
            //};

            //var list3 = new ListNode(-2)
            //{
            //    next = new ListNode(-1)
            //    {
            //        next= new ListNode(0)
            //        {
            //            next = new ListNode(2)
            //        }
            //    }
            //};

            var lists = new ListNode[]
            {
                list1
            };

            var result = new MergeKSortedLL().Run1(lists);

            while (result != null)
            {
                Console.Write("     {0}", result.val);
                result = result.next;
            }
        }

        private static void LengthOfLongestSubstring()
        {
            Console.WriteLine("The length of longest substring is: {0}", new LengthOfLongestSubstring().Run("dvdf"));
        }

        private static void FindMedianSortedArrays()
        {
            //var arr1 = new int[] { 1, 3, 8, 9, 15,33 };
            //var arr2 = new int[] { 7, 11, 18, 19, 21, 25 };

            var arr1 = new int[] { 3 };
            var arr2 = new int[] { };


            Console.WriteLine("The median is: {0}", new FindMedianSortedArrays().Run(arr1, arr2));
        }

        private static void BuildTreeFromPreAndInOrder()
        {
            var preOrder = new List<int> { 9, 7, 2, 4, 15, 19, 21, 6, 3 };
            var inOrder = new List<int> { 2, 7, 4, 9, 19, 15, 6, 21, 3 };

            //var preOrder = new List<int> { 3, 9, 20, 15, 7 };
            //var inOrder = new List<int> { 9, 3, 15, 20, 7 };

            var result = new BuildTreeFromPreAndInOrder().Run(preOrder, inOrder);

            Console.WriteLine("Root value: {0}", result.Item1.Value);
            Console.WriteLine("Left value: {0}", result.Item1.Left.Value);
            Console.WriteLine("Right value: {0}", result.Item1.Right.Value);
        }

        private static void AddTwoLLNumbers()
        {
            var linkedList1 = new DataStructures.SinglyLinkedList<int>
            {
                Value = 0,
                Next = new DataStructures.SinglyLinkedList<int>
                {
                    Value = 0,
                    Next = new DataStructures.SinglyLinkedList<int>
                    {
                        Value = 1
                    }
                }
            };

            var linkedList2 = new DataStructures.SinglyLinkedList<int>
            {
                Value = 0,
                Next = new DataStructures.SinglyLinkedList<int>
                {
                    Value = 0,
                    Next = new DataStructures.SinglyLinkedList<int>
                    {
                        Value = 9,
                        Next = new DataStructures.SinglyLinkedList<int>
                        {
                            Value = 9
                        }
                    }
                }
            };

            var result = new AddTwoLLNumbers().Run(linkedList1, linkedList2);

            while (result != null)
            {
                Console.Write(result.Value);
                result = result.Next;
                if (result != null)
                {
                    Console.Write(" -> ");
                }
            }
        }
    }
}
