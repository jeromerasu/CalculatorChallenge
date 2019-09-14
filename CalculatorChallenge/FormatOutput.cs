using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    class FormatOutput
    {
        public int GetNumbersFromArgument(String argString)
        {
            int sum = 0;
            String[] sArr = argString.Split(',');
            for (int i = 0; i < 2; i++)
            {
                int temp;
                Int32.TryParse(sArr[i], out temp);
                sum += temp;
            }
            return sum;
        }
    }
}
