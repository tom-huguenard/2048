using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2048
{
    public class Randomizer
    {
        public List<int> GetRandomNumbers(int numberToGet)
        {
            var rtn = new List<int>();
            var r = new Random((int) DateTime.Now.Ticks);

            while (rtn.Count < numberToGet)
            {
                rtn.Add(r.Next(0, 15));
                rtn = rtn.Distinct().ToList();
            }

            return rtn;
        }

        public int GetRandomIndexIntoArray(int[] values)
        {
            var l = new List<int>();
            for (var i = 0; i < values.Length; i++)
                if (values[i] == 0)
                    l.Add(i);

            var r = new Random((int) DateTime.Now.Ticks);


            var rtn = r.Next(0, l.Count);
            return l[rtn];

        }
    }
}
