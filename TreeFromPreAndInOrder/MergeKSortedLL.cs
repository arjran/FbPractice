using FacebookPractice.LeetCode;

namespace FacebookPractice
{
    class MergeKSortedLL
    {
        public ListNode Run1(ListNode[] lists)
        {
            return SortLists(lists, 0, lists.Length - 1);
        }

        private ListNode SortLists(ListNode[] lists, int start, int end)
        {
            if (lists.Length <= 1)
            {
                return lists.Length == 0 ? null : lists[0];
            }

            if (start >= end) { return null; }
            int mid = (start + end) / 2;
            SortLists(lists, start, mid);
            SortLists(lists, mid + 1, end);
            return Merge(lists, start, end);
        }

        private ListNode Merge(ListNode[] lists, int start, int end)
        {
            var list1 = lists[start];
            var list2 = lists[end];

            var head = list2;
            ListNode prev = null;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    if (prev == null)
                    {
                        head = list1;
                    }
                    else
                    {
                        prev.next = list1;
                    }

                    prev = list1;
                    var temp = list1.next;
                    list1.next = list2;
                    list1 = temp;
                }
                else
                {
                    prev = list2;
                    list2 = list2.next;
                }
            }

            if (list2 == null && list1 != null)
            {
                if (prev != null)
                {
                    prev.next = list1;
                }
                else
                {
                    head = list1;
                }
            }

            for (int i = start; i <= end; i++)
            {
                lists[i] = head;
            }

            return head;
        }

        public ListNode Run2(ListNode[] lists)
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

                            while (node.next != null
                            && resultList.val >= node.next.val)
                            {
                                node = node.next;
                            }
                        }
                        else
                        {
                            firstResult = node;
                        }

                        nextNode = node.next;
                        node.next = resultList;
                    }
                    else
                    {
                        resultList.next = node;
                        break;
                    }

                    node = nextNode;
                }
            }

            return firstResult;
        }
    }
}
