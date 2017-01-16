using System;
using System.Collections.Generic;
using System.Linq;

namespace P2048
{
    public class RowData
    {
        private int[] _values;
        public int RowNumber { get; set; }
        public void SetData(int[] data)
        {
            _values = data;
        }

        public int[] GetData()
        {
            return _values;
        }

        public void Coalesce()
        {
            var list = EliminateLeadingZeroes(_values);
            list = CombineAdjacentValues(list);
            CreateValuesFromList(list);
        }

        private void CreateValuesFromList(List<int> list)
        {
            list.AddRange(new [] { 0,0,0,0});
            _values = list.Take(4).ToArray();
        }


        private static List<int> CombineAdjacentValues(List<int> list)
        {
            for (var i = 0;i < list.Count-1;i++)
                CoalescePair(list, i);
            return list;
        }

        private static void CoalescePair(List<int> list, int element)
        {
            if (list.Count < element + 1) return;
            if (list[element] != list[element + 1]) return;

            list[element] = list[element] * 2;
            list.RemoveAt(element+1);
        }

        private static List<int> EliminateLeadingZeroes(int[] list)
        {
            var i = 0;
            return list
                .Select(x => new Tuple<int, int>(i++, x))
                .Where(x => x.Item2 != 0)
                .OrderBy(x => x.Item1)
                .Select(x => x.Item2)
                .ToList();

        }
    }
}
