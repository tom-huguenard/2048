using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P2048;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        public void CompareArrays(int[] a, int[] b)
        {
            if (a.Length!= b.Length) Assert.Fail("arrays of different length");
            for (var i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    Assert.Fail("arrays differ");
        }


        [TestMethod]
        public void CoalesceShouldMoveSingleValueToFirstPosition()
        {
            var initial = new[] { 0, 0, 0, 1 };
            var expected = new[] { 1, 0, 0, 0 };

            var r = new RowData();
            r.SetData(initial);
            r.Coalesce();
            var result = r.GetData();
            CompareArrays(expected, result);
        }
        [TestMethod]
        public void CoalesceShouldMoveTwoValuesToFirstAndSecondPosition()
        {
            var initial = new[] { 0, 0, 2, 1 };
            var expected = new[] { 2, 1, 0, 0 };

            var r = new RowData();
            r.SetData(initial);
            r.Coalesce();
            var result = r.GetData();
            CompareArrays(expected, result);
        }
        [TestMethod]
        public void CoalesceShouldJoinTwoEqualValues()
        {
            var initial = new[] { 0, 0, 2, 2 };
            var expected = new[] { 4, 0, 0, 0 };

            var r = new RowData();
            r.SetData(initial);
            r.Coalesce();
            var result = r.GetData();
            CompareArrays(expected, result);
        }
        [TestMethod]
        public void CoalesceShouldJoinFourEqualValuesIntoTwoDoubleValue()
        {
            var initial = new[] { 2, 2, 2, 2 };
            var expected = new[] { 4, 4, 0, 0 };

            var r = new RowData();
            r.SetData(initial);
            r.Coalesce();
            var result = r.GetData();
            CompareArrays(expected, result);
        }
    }
}
