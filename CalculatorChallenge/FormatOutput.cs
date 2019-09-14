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
            if (checkIfCustomDelimiter(argString))
            {
                List<String> delims = getDelimiters(argString);
                //replace all delimiters with commas as well as new lines, make sure delim is 
                if (delims.Count > 0)
                {
                    foreach (String delim in delims)
                    {
                        argString = argString.Replace(delim, ",");
                    }
                }
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
        /// Will return if string contains custom characters or not
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        public Boolean checkIfCustomDelimiter(String argString)
        {
            Char[] argChars = argString.ToCharArray();
            return (argChars[0] == '/') && (argChars[1] == '/');
        }
        /// <summary>
        /// returns delimiters, assumes delimiters will not include [ or ] characters
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        private static List<String> getDelimiters(String argString)
        {
            List<String> customDelimiters = new List<String>();
            Char[] argChars = argString.ToCharArray();
            StringBuilder sb = new StringBuilder();

            Boolean withinBracket = true;
            //start at 2 because that will either be a [ or a single character.
            for (int i = 2; i < argChars.Length; i++)
            {
                if (argChars[2] != '[')
                {
                    customDelimiters.Add(argChars[2].ToString());
                    return customDelimiters;
                }
                //since we're only returning one delimiter, function will break once we reach
                if (argChars[i] == ']')
                {
                    int temp;
                    if (Int32.TryParse(sb.ToString(), out temp))
                    {
                        ///we do not want to have a delimiter that can be parsed as a number
                        Console.WriteLine("custom delimiter not valid");
                    }
                    else
                    {
                        withinBracket = false;
                        customDelimiters.Add(sb.ToString());
                    }
                }
               if (argChars[i] == '[')
                {
                    sb = new StringBuilder();
                    withinBracket = true;
                    continue;
                }
               if (withinBracket)
                {
                    sb.Append(argChars[i]);
                }
            }

            return customDelimiters;
        }
    }
}
