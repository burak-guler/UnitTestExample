using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TestExample.Test.TestData;

namespace TestExample.Test
{
    //instance’ı tek seferde constructor üzerinden de oluşturabiliriz.
    //    Burada özellikle dikkat edilmesi gereken nokta şudur ki, xUnit.Net her birim testi için bulunduğu sınıfın bir instance’ını almaktadır.Haliyle bu örnekte dört farklı metot olduğuna göre test sürecinde dört farklı nesne oluşturuldu demektir.

    //Dolayısıyla xUnit.Net, her bir birim için instance üretmesinden dolayı bir test bitmeden diğerine geçmeyecektir.


    public class MathematicsUnitTest
    {
        Mathematics _mathematics;
        public MathematicsUnitTest()
        {
            _mathematics = new();
        }

        [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void SumTest(int number1, int number2, int expected)
        {
            #region Act
            int result = _mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Fact]
        public void SubtractTest()
        {
            #region Arrange
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            #endregion
            #region Act
            int result = _mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Theory, InlineData(3, 5)]
        public void MultiplyTest(int number1, int number2)
        {
            #region Act
            int result = _mathematics.Multiply(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(15, result);
            #endregion
        }

        [Theory, InlineData(30, 5, 6)]
        public void DivideTest(int number1, int number2, int expected)
        {
            #region Act
            int result = _mathematics.Divide(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
