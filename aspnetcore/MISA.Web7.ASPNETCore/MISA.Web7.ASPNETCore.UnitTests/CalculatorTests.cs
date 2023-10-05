using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Hàm unit test tổng 2 số
        /// </summary>
        [TestCase(1, 1, 2)]
        [TestCase(1, -1, 0)]
        [TestCase(1, int.MaxValue, (long)1 + int.MaxValue)]
        public void Add_ValidInput_Sum2Digit(int x, int y, long expectedResult)
        {
            // Arrange

            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Add(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1, 0)]
        [TestCase(2, 3, -1)]
        [TestCase(1, int.MaxValue, (long)1 - int.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue, (long)2 * int.MaxValue + 1)]
        public void Sub_ValidInput_Sum2Digit(int x, int y, long expectedResult)
        {
            // Arrange

            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Sub(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, 3, 6)]
        [TestCase(int.MaxValue, int.MinValue, (long)int.MinValue * int.MaxValue)]
        public void Mul_ValidInput_Sum2Digit(int x, int y, long expectedResult)
        {
            // Arrange

            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Mul(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        public void Div_DivideByZero_ThrowException()
        {
            // Arrange

            var x = 1;
            var y = 0;
            var expectedMessage = "Không chia được cho 0";

            var calculator = new Calculator();

            //Act & Assert
            try
            {
                var actualResult = calculator.Div(x, y);

            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        [TestCase(1, 1, 1)]
        [TestCase(2, -3, -2/(float)3)]
        [TestCase(2, -3, -0.666666)]
        public void Div_ValidInput_Sum2Digit(int x, int y, double expectedResult)
        {
            // Arrange

            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Div(x, y);

            // Assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-6));
        }

        /// <summary>
        /// Kiểm tra có đúng định dạng số không
        /// </summary>
        /// <param name="s">Chuỗi truyền vào</param>
        /// CreatedBy: nnanh - 12/9/23
        [TestCase("1a,b2,c")]
        [TestCase("@@!,-1,")]
        public void Add_IncorectFormat_ThrowException(string s)
        {
            // Arange
            var expectedMsg = "Chuỗi không hợp lệ";
            var calculator = new Calculator();

            // Act & Assert
            try
            {
                var actualResult = calculator.Add(s);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMsg));
            }
        }


        /// <summary>
        /// Kiểm tra có toán hạng âm không
        /// </summary>
        /// <param name="s">Chuỗi truyền vào</param>
        /// <param name="expectedMsg">Thông báo lỗi</param>
        /// CreatedBy: nnanh - 12/9/23
        [TestCase("1,-2,-3", "Không chấp nhận toán hạng âm: -2,-3")]
        [TestCase("-11, 2,-3", "Không chấp nhận toán hạng âm: -11,-3")]
        public void Add_ValidInput_ThrowException(string s, string expectedMsg)
        {
            // Arange
            var calculator = new Calculator();

            // Act & Assert
            try
            {
                var actualResult = calculator.Add(s);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMsg));
            }
        }

        /// <summary>
        /// Kiểm tra tính tổng có đúng với kết qua mong đợi không
        /// </summary>
        /// <param name="s">Chuỗi trên vào</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: nnanh - 12/9/23
        [TestCase("", 0)]
        [TestCase("2", 2)]
        [TestCase("  223  ", 223)]
        [TestCase("1, 1, 1,2 , 3", 8)]
        [TestCase("1.5, 3.5", 5)]
        [TestCase("1.5, 3.623", 5.123)]
        [TestCase("1.5, ,3.623", 5.123)]
        [TestCase("  ,   ,  ", 0)]
        public void Add_ValidInput_SumOfString(string s, double expectedResult)
        {
            // Arrange

            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Add(s);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
