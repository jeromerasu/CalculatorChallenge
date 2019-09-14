using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    public class FormatOutput
    {
        /// <summary>
        /// Formats arg string into values that can add all numbers that are non negative and less than a thousand.
        /// Format is "1,2" or custom delimiter IE "//[..]\n1..2..3" 
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        public int GetNumbersFromArgument(String argString)
        {
            int sum = 0;
            //custom delimiters will always be first line or first line separated by a new line according to readme
            String delim = getDelimiters(argString);
            //replace all delimiters with commas as well as new lines, make sure delim is 
            if (!delim.Equals(""))
            {
                argString = argString.Replace(delim, ",");
            }
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
        /// <summary>
        /// returns de
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        private static String getDelimiters(String argString)
        {
            StringBuilder sb = new StringBuilder();
            Char[] argChars = argString.ToCharArray();
            for (int i = 1; i < argChars.Length; i++)
            {
                //since we're only returning one delimiter, function will break once we reach
                if(argChars[i] == ']')
                {
                    break;
                }
               if (argChars[i-1] == '[')
                {
                    sb.Append(argChars[i]);
                }
            }
            int temp;
            if (Int32.TryParse(sb.ToString(), out temp))
            {
                ///we do not want to have a delimiter that can be parsed as a number
                return "";
            }
            return sb.ToString();
        }
    }
}
