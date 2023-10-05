namespace MISA.Web7.ASPNETCore
{
    public class Calculator
    {
        public long Add(int x, int y) { return x + (long)y; }
        public long Sub(int x, int y) { return x - (long)y; }

        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không chia được cho 0");
            };
            return x / (double)y;
        }


        /// <summary>
        /// Tính tổng các số từ một chuỗi phân cách bởi dấu phẩy
        /// </summary>
        /// <param name="s">Chuỗi truyền vào</param>
        /// <returns>
        /// Exception Chuỗi không hợp lệ: chuỗi truyền vào không phải dạng số
        /// Exception Không chấp nhận toán hạng âm: nếu chuỗi có chứa số âm
        /// Tổng các số: nếu qua các exception
        /// </returns>
        /// <exception cref="Exception">Thông báo lỗi</exception>
        /// CreatedBy: nnanh - 12/9/23
        public double Add(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var ArrStrings = s.Split(',');

            for (int i = 0; i < ArrStrings.Length; i++)
            {

                ArrStrings[i] = ArrStrings[i].Trim();
                if (ArrStrings[i] == "") ArrStrings[i] = "0";
            }

            var numbers = Array.ConvertAll(ArrStrings, ele =>
            {
                if (!double.TryParse(ele, out double num))
                {
                    throw new Exception("Chuỗi không hợp lệ");
                }
                return num;
            });

            List<double> negativeNumbers = new();

            var sum = 0d;

            foreach (var number in numbers)
            {

                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }

                sum += number;

            }
            if (negativeNumbers.Count > 0)
            {
                throw new Exception($"Không chấp nhận toán hạng âm: {string.Join(",", negativeNumbers)}");
            }
            return sum;
        }
    }
}
