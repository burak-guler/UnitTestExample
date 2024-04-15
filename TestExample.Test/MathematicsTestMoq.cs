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
        [Fact]
        public void SumTest()
        {
            var mathematics = new Mock<IMathematicsService>();
            mathematics.Setup(m => m.Sum(1, 2))
                .Returns(3);
            int result = mathematics.Object.Sum(1, 2);

            Assert.Equal(3, result);
        }
    }
}
