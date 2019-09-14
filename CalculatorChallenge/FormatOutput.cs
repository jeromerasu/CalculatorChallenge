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
            foreach (String s in sArr)
            {
                int temp;
                Int32.TryParse(s, out temp);
                sum += temp;
            }
            return sum;
        }
    }
}
