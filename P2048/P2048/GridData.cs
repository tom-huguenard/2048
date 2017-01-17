using System.Collections.Generic;
using System.Linq;

namespace P2048
{
    public class GridData
    {
        public int[] Values { get; set; }
        public GridData()
        {
            Values = new int[16];
            
            var r = new Randomizer();
            var randoms = r.GetRandomNumbers(2);
            Values[randoms[0]] = 2;
            Values[randoms[1]] = 2;
        }
        public int ValueForRowAndColumn(int row, int column)
        {
            return Values[row*4 + column];
        }
        public void MoveRowDataForDirection(string moveType)
        {
            switch (moveType.ToLower().First())
            {
                case 'u':
                    MoveDataByPositionAndOffset(12, -4, 1);
                    break;
                case 'd':
                    MoveDataByPositionAndOffset(0, 4, 1);
                    break;
                case 'l':
                    MoveDataByPositionAndOffset(3, -1, 4);
                    break;
                case 'r':
                    MoveDataByPositionAndOffset(0, 1, 4);
                    break;
            }

        }
        private void MoveDataByPositionAndOffset(int start, int offsetBrother, int offsetParent)
        {
            for(var l = 0; l < 4;l++)
            {
                var i = start + l*offsetParent;
                var d = new List<int>();
                for (var k = 0; k < 4; k++)
                {
                    var j = i + k*offsetBrother;
                    d.Add(Values[j]);
                }

                var r = new RowData {RowNumber = i};
                r.SetData(d.ToArray());
                r.Coalesce();
                d = r.GetData().ToList();

                for (var k = 0; k < 4; k++)
                {
                    var j = i + k * offsetBrother;
                    Values[j] = d[k];
                }
            }
        }
        public void AddNewValue()
        {
            var r = new Randomizer();
            var pos = r.GetRandomIndexIntoArray(Values);
            Values[pos] = 2;
        }
    }
}
