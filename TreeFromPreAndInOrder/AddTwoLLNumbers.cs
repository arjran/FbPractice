using FacebookPractice.DataStructures;

namespace FacebookPractice
{
    class AddTwoLLNumbers
    {
        public SinglyLinkedList<int> Run(SinglyLinkedList<int> firstList, SinglyLinkedList<int> secondList)
        {
            SinglyLinkedList<int> listStart = null;
            SinglyLinkedList<int> resultList = null;
            var carryOver = false;

            while (firstList != null || secondList != null || carryOver)
            {
                if (resultList == null)
                {
                    resultList = new SinglyLinkedList<int>();
                    listStart = resultList;
                }
                else
                {
                    resultList.Next = new SinglyLinkedList<int>();
                    resultList = resultList.Next;
                }
                
                var firstListValue = firstList != null ? firstList.Value : 0;
                var secondListValue = secondList != null ? secondList.Value : 0;
                var result = firstListValue + secondListValue + (carryOver ? 1 : 0);
                carryOver = false;

                if (result > 9)
                {
                    carryOver = true;
                    result -= 10;
                }

                resultList.Value = result;
                firstList = firstList?.Next;
                secondList = secondList?.Next;
            }
            
            return listStart;
        }
    }
}
