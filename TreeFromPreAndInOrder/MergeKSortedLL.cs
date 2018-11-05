using FacebookPractice.LeetCode;

namespace FacebookPractice
{
    class MergeKSortedLL
    {
        public ListNode Run(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }

            ListNode resultList = lists[0];

            var i = 1;
            while (resultList == null && i < lists.Length)
            {
                resultList = lists[i];
                i++;
            }

            if (resultList == null)
            {
                return null;
            }

            ListNode firstResult = resultList;

            for (; i < lists.Length; i++)
            {
                var node = lists[i];

                while (node != null)
                {
                    ListNode prevResult = null;
                    resultList = firstResult;
                    var nextNode = node.next;

                    while (node.val > resultList.val && resultList.next != null)
                    {
                        prevResult = resultList;
                        resultList = resultList.next;
                    }

                    if (node.val <= resultList.val)
                    {
                        if (prevResult != null)
                        {
                            prevResult.next = node;
                        }
                        else
                        {
                            firstResult = node;
                        }

                        node.next = resultList;
                    }
                    else
                    {
                        resultList.next = node;
                        node.next = null;
                    }

                    node = nextNode;
                }
            }

            return firstResult;
        }
    }
}
