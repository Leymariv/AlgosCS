using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Algos
{
    public static class Algo
    {
        public static void FillTree(NodeTree root, IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                InsertValue(root, value);
            }
        }

        public static NodeTree InsertValue(NodeTree root, int value)
        {
            if (root == null)
            {
                return new NodeTree(value, null, null);
            }
            if (value < root.Value)
            {
                root.Left = InsertValue(root.Left, value);
            }
            else
            {
                root.Right = InsertValue(root.Right, value);
            }
            return root;
        }

        public static bool TreeContainsRec(NodeTree root, int value)
        {
            if (root == null)
            {
                return false;
            }
            if (root.Value == value)
            {
                return true;
            }
            return TreeContainsRec(value > root.Value ? root.Right : root.Left, value);
        }

        public static bool TreeContainsIt(NodeTree root, int value)
        {
            var current = root;
            while (current != null)
            {
                if (value == current.Value)
                {
                    return true;
                }
                current = value > current.Value ? current.Right : current.Left;
            }
            return false;
        }

        public static bool IsBalancedRec(NodeTree root)
        {
            if (root != null)
            {
                var left = MyWeight(root.Left);
                var right = MyWeight(root.Right);
                if (Math.Abs(left - right) > 1)
                {
                    return false;
                }
                IsBalancedRec(root.Left);
                IsBalancedRec(root.Right);
            }
            return true;
        }

        public static int MyWeight(NodeTree root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(MyWeight(root.Left), MyWeight(root.Right));
        }

        public static NodeList GetMid(NodeList head)
        {
            var current = head;
            var middle = head;
            var index = 1;
            var two = 2;
            while (current != null)
            {
                current = current.Next;
                if (index % two == 0)
                {
                    middle = middle.Next;
                }
                index++;
            }
            return middle;
        }

        /*
         * 1 2 3 4 5 6 7 8
         * ======>
         *       5
         *    3    7
         *   2 4  6 8
         *  1 
         *  
         */

        public static NodeTree BuildBalancedTree(IEnumerable<int> list)
        {
            if (list == null || !list.Any())
            {
                return null;
            }
            int two = 2;
            var indexMid = list.Count() / two;
            var newRoot = new NodeTree(list.ElementAt(indexMid), null, null);
            List<int> subListLeft = list.Take(indexMid).ToList();
            newRoot.Left = BuildBalancedTree(subListLeft);
            var lastindex = list.Count();
            var countFromIndexMid = lastindex - (indexMid + 1);
            List<int> subListRight = list.Skip(indexMid + 1).Take(countFromIndexMid).ToList();
            newRoot.Right = BuildBalancedTree(subListRight);
            return newRoot;
        }

        public static IEnumerable<int> RootToList(NodeTree root)
        {
            if (root != null)
            {
                foreach (var i in RootToList(root.Left))
                {
                    yield return i;
                }
                foreach (var i in RootToList(root.Right))
                {
                    yield return i;
                }
                yield return root.Value;
            }
        }

        public static void RootToList2(NodeTree root, Collection<int> list)
        {
            if (root == null)
            {
                return;
            }
            RootToList2(root.Left, list);
            RootToList2(root.Right, list);
            list.Add(root.Value);
        }

        /* Breadth First Search */

        public static IEnumerable<int> RootToHorizontalList(NodeTree root)
        {
            if (root == null)
            {
                return null;
            }

            var list = new List<int>();
            list.Add(root.Value);

            var queue = new Queue<NodeTree>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Left != null)
                {
                    list.Add(current.Left.Value);
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    list.Add(current.Right.Value);
                    queue.Enqueue(current.Right);
                }
            }
            return list;
        }

        public static void BubbleSort(int[] tab)
        {
            var leftToConsider = tab.Length;
            var hasSwaped = true;

            while (leftToConsider > 1 && hasSwaped)
            {
                hasSwaped = false;
                for (var i = 0; i < leftToConsider - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        Swap(tab, i, i + 1);
                        hasSwaped = true;
                    }
                }
                leftToConsider--;
            }
        }

        public static void BubbleSortRec(int[] tab, int size)
        {
            if (size > 1)
            {
                var index = size - 1;
                var ret = tab;
                var indexMax = 0;
                for (var i = 1; i <= index; i++)
                {
                    if (ret[indexMax] < ret[i])
                    {
                        indexMax = i;
                    }
                }
                var temp = ret[indexMax];
                ret[indexMax] = ret[index];
                ret[index] = temp;
                BubbleSortRec(ret, index);
            }
        }

        public static void Quicksort(int[] tab, int left, int right)
        {
            if (left < right)
            {
                var wall = left;
                for (var i = left; i < right; i++)
                {
                    if (tab[i] <= tab[right])
                    {
                        Swap(tab, wall++, i);
                    }
                }
                Swap(tab, wall, right);
                Quicksort(tab, left, wall - 1);
                Quicksort(tab, wall + 1, right);
            }
        }

        public static void Swap(int[] tab, int indexFrom, int indexTo)
        {
            var temp = tab[indexFrom];
            tab[indexFrom] = tab[indexTo];
            tab[indexTo] = temp;
        }

        public static int SumRec(int index)
        {
            int one = 1;
            return index == 0 ? 0 : index + SumRec(index - one);
        }

        public static int FibonacciIt(int number)
        {
            var result = 1;
            var res1 = 1;
            var res2 = 1;
            for (var i = 2; i <= number; i++)
            {
                result = res1 + res2;
                res2 = res1;
                res1 = result;
            }
            return result;
        }

        public static int FibonacciRec(int number)
        {
            int one = 1, two = 2;
            return number == 0 || number == one ? one : FibonacciRec(number - one) + FibonacciRec(number - two);
        }
    }
}