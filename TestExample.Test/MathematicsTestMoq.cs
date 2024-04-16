using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExample.MathematicsService;

namespace TestExample.Test
{
    public class MathematicsTestMoq
    {

        //aşağıdaki kod parçasına göz atarsanız eğer ‘Mock’ sınıfına generic olarak ‘IMathematics’ interface’i verilmekte ve böylece hangi interface içerisindeki metotların simüle edileceği bildirilmiş olunmaktadır. ilgili interface içerisinde simüle edilecek olan metot ‘Setup’ edilmekte ve böylece simüle sürecinde verilecek ‘1’ ve ‘2’ parametre değerlerine karşı geriye ‘3’ değerinin dönmesi gerektiği bildirilmektedir.artık simülasyon ayarları bitmiş olan ‘Mock’ nesnesi üzerinden ‘Object’ property’si ile üretilen nesne çağrılmakta ve ilgili metot tetiklenmektedir
        [Fact]
        public void SumTest()
        {
            var mathematics = new Mock<IMathematicsService>(); 
            mathematics.Setup(m => m.Sum(1, 2))
                .Returns(3);
            int result = mathematics.Object.Sum(1, 2);

            Assert.Equal(3, result);

            mathematics.Verify(x => x.Sum(1, 2), Times.AtLeast(1));
        }
    }
}
