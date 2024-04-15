using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using TestExample.Test.TestData;

namespace TestExample.Test
{
    public class MathematicsTest
    {
        [Fact]
        public void SubtractTest()
        {
            #region Arrange
            //Kaynaklar hazırlanıyor.
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
            int result = mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            //Test neticesinde gelen data doğrulanıyor.
            Assert.Equal(expected, result);
           
            #endregion
        }

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(33, 55, 88)]
        [InlineData(333, 555, 888)]
        [InlineData(33, 44, 87)]
        public void SumTest(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }


        public static IEnumerable<object[]> sumDatas => new List<object[]> {
                new object[]{ 3, 5, 8 },
                new object[]{ 11, 5, 16 },
                new object[]{ 23, 2, 25 },
                new object[]{ 33, 44, 87 }
        };


        //‘MemberData’ attribute’u ile kullanılacak member türü IEnumerable<object[]> ve static olmak zorundadır.İlgili yapıda belirtilen member üzerinden test sürecinde istenilen değerler parametre olarak hızlıca geçilebilmektedir

        [Theory]
        [MemberData(nameof(sumDatas))]
        public void SumTest2(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        //Eğer ki bu member farklı bir class’ın üyesi olsaydı aşağıdaki gibi ‘MemberType’ property’si üzerinden sınıf bildiriminde bulunarak çalışma yapılması yeterli olacaktı;

        [Theory]
        [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas))]
        public void SumTestMember(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }


        //Ayrıca ‘MemberData’ ile yapılan test süreçlerinde veri seti yüzlerce yahut binlerce olanlar için ‘Test Explorer’da tek bir sonuç elde etmek istiyorsak eğer “DisableDiscoveryEnumeration” özelliğine ‘true’ vermemiz yeterli olacaktır.

        [Theory]
        [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas), DisableDiscoveryEnumeration = true)]
        public void SumTestDisable(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }


        [Theory]
        [ClassData(typeof(DatasEnumerable))]
        public void SumTestEnumerableClass(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }


        //Peki, IEnumerable<object[]> yerine IEnumerable<string[]> yahut IEnumerable<int[]> gibi tip güvenli test verilerini nasıl yazabiliriz?
        //Bunun içinde ‘TheoryData’ attribute’undan faydalanabiliriz.Şöyle ki;
        //Görüldüğü üzere tip güvenliğini kullanabilmek için yukarıdaki gibi ‘TheoryData’ class’ından faydalanabilmekteyiz.
    
            [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void SumTestTheoryData(int number1, int number2, int expected)
        {
            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

    }
}
