using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maytinh.Service
{
    internal class ProgammerS
    {
     //Chuyển đổi từ một cơ số bất kỳ sang cơ số 10 (thập phân)
        public int ConvertToDecimal(string value, int fromBase)
        {
            return Convert.ToInt32(value, fromBase);
        }
        // Chuyển đổi từ cơ số 10 (thập phân) sang cơ số bất kỳ
        public string ConvertFromDecimal(int value, int toBase)
        {
            return Convert.ToString(value, toBase);
        }
        // Chuyển đổi giữa các cơ số khác nhau
        public string ConvertBetweenBases(string value,int fromBase, int toBase)
        {
            int decimalValue = ConvertToDecimal(value, fromBase);
            return ConvertFromDecimal(decimalValue, toBase);
        }
    }
}
