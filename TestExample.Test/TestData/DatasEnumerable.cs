using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestExample.Test.TestData
{
    //Ayrıca ‘MemberData’ attribute’una alternatif olarak ‘ClassData’ attribute’unu da kullanabiliriz.
    //    Tabi ‘ClassData’ attribute’u, dataları alacağı sınıfa IEnumerable<object[]> arayüzünü implemente etmemizi ve ‘GetEnumerator’ içerisinde yield ile dataları itere etmemizi istemektedir.
    public class DatasEnumerable : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 3, 5, 8 };
            yield return new object[] { 11, 5, 16 };
            yield return new object[] { 23, 2, 25 };
            yield return new object[] { 33, 44, 87 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
