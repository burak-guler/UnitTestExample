using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.Test.TestData
{
    //Peki, IEnumerable<object[]> yerine IEnumerable<string[]> yahut IEnumerable<int[]> gibi tip güvenli test verilerini nasıl yazabiliriz?
    //Bunun içinde ‘TheoryData’ attribute’undan faydalanabiliriz.Şöyle ki;
    //Görüldüğü üzere tip güvenliğini kullanabilmek için yukarıdaki gibi ‘TheoryData’ class’ından faydalanabilmekteyiz.
    public class TypeSafeData : TheoryData<int, int, int>
    {
        public TypeSafeData()
        {
            Add(3, 5, 8);
            Add(11, 5, 16);
            Add(23, 2, 25);
            Add(33, 44, 87);
        }
    }
}
