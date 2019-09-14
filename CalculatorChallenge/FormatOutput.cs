using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    public class FormatOutput
    {
        public int GetNumbersFromArgument(String argString)
        {
            int sum = 0;
            argString = argString.Replace("\n", ",");
            String[] sArr = argString.Split(',');
            Boolean negNumbersDetected = false;
            List<Int32> negNumbers = new List<int>();
            foreach (String s in sArr)
            {
                int temp;
                Int32.TryParse(s, out temp);
                if (temp > 1000)
                {
                    temp = 0;
                }
                if (temp < 0)
                {
                    negNumbersDetected = true;
                    negNumbers.Add(temp);
                }
                sum += temp;
            }
            if (negNumbersDetected)
            {
                throw NegativeNumberException.Return(negNumbers);
            }
            return sum;
        }
    }
}
