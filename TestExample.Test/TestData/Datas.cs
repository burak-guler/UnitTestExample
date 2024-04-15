using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.Test.TestData
{
    public class Datas
    {
        public static IEnumerable<object[]> sumDatas => new List<object[]> {
        new object[]{ 3, 5, 8 },
        new object[]{ 11, 5, 16 },
        new object[]{ 23, 2, 25 },
        new object[]{ 33, 44, 87 }
    };
    }
}
