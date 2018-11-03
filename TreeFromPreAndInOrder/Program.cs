using System;
using System.Collections.Generic;

namespace FacebookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //BuildTreeFromPreAndInOrder();
            AddTwoLLNumbers();
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
            Console.ReadLine();
        }

        private static void AddTwoLLNumbers()
        {
            var linkedList1 = new DataStructures.LinkedList<int>
            {
                Value = 0,
                Next = new DataStructures.LinkedList<int>
                {
                    Value = 0,
                    Next = new DataStructures.LinkedList<int>
                    {
                        Value = 1
                    }
                }
            };

            var linkedList2 = new DataStructures.LinkedList<int>
            {
                Value = 0,
                Next = new DataStructures.LinkedList<int>
                {
                    Value = 0,
                    Next = new DataStructures.LinkedList<int>
                    {
                        Value = 9,
                        Next = new DataStructures.LinkedList<int>
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
                if(result != null)
                {
                    Console.Write(" -> ");
                }
            }

            Console.ReadLine();
        }
    }
}
