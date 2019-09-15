using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    public class FormatOutput
    {
        /// <summary>
        /// Formats arg string into values that can add all numbers that are non negative and less than a thousand.
        /// Format is "1,2" or custom delimiter IE "//[..]\n1..2..3" \n will be converted to \\n
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
            
        public CalculateOutputLine GetNumbersFromArgument(String argString, Boolean allowNeg, String alternateDelim, int upperBound, int operation, Boolean consoleApp)
        {
            try
            {
                if (argString == null || argString.Length == 0)
                {
                    return null;
                }
                //doing this for testing purposes

                
                //custom delimiters will always be first line or first line separated by a new line according to readme
                if (checkIfCustomDelimiter(argString))
                {
                    String delimString = "";
                    if (consoleApp)
                    {
                        delimString = argString.Split("\\n")[0];
                    }
                    else
                    {
                        delimString = argString.Split(Environment.NewLine)[0];
                    }
                        List<String> delims = getDelimiters(delimString);
                    //use for actual inputs
                    if (!consoleApp)
                    {
                        argString = argString.Replace(delimString + Environment.NewLine, "");
                    }
                    else
                    {
                        //use for console app input
                        argString = argString.Replace(delimString + "\\n", "");
                    }
                    //replace all delimiters with commas as well as new lines, make sure delim is 
                    if (delims.Count > 0)
                    {
                        foreach (String delim in delims)
                        {
                            argString = argString.Replace(delim, ",");
                        }
                    }
                    //first entry will always be the 
                }
                //have to factor in each potential arg
                if (!consoleApp)
                {
                    argString = argString.Replace(Environment.NewLine, alternateDelim);
                }
                else
                {
                    //for console input
                    argString = argString.Replace("\\n", alternateDelim);
                }
                argString = argString.Replace(alternateDelim, ",");
         
                String[] sArr = argString.Split(',');
                var calcLine = ProductOutputLine(sArr, allowNeg, upperBound, operation);
                return calcLine;
            } catch (NegativeNumberException e)
            {
                Console.WriteLine(e);
                return null;
            } catch (OverflowException e)
            {
                Console.WriteLine("Number was too big");
                Console.WriteLine(e);
                return null;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public CalculateOutputLine GetDefaultCalc(String args)
        {
            return GetNumbersFromArgument(args, false, Environment.NewLine, 1000, 1, false);
        }

        public CalculateOutputLine TestCalculateProductLine(String[] sArr)
        {
            return ProductOutputLine(sArr, false, 1000, 1);
        }
        /// <summary>
        /// Cal
        /// </summary>
        /// <param name="sArr"></param>
        /// <param name="allowNeg"></param>
        /// <param name="upperBound"></param>
        /// <param name="operation"></param>
        /// <returns></returns>

        private static CalculateOutputLine ProductOutputLine(String[] sArr, Boolean allowNeg, Int32 upperBound, int operation)
        {
            Boolean negNumbersDetected = false;
            List<Int32> negNumbers = new List<int>();
            List<Int32> nums = new List<Int32>();
            foreach (String s in sArr)
            {
                int temp;
                Int32.TryParse(s, out temp);
                if (temp > upperBound)
                {
                    temp = 0;
                }
                if (!allowNeg)
                {
                    if (temp < 0)
                    {
                        negNumbersDetected = true;
                        negNumbers.Add(temp);
                    }
                }
                nums.Add(temp);
            }

            if (negNumbersDetected)
            {
                throw NegativeNumberException.Return(negNumbers);
            }

            return new CalculateOutputLine(nums, operation);
        }

        /// <summary>
        /// Will return if string contains custom characters or not
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        private static Boolean checkIfCustomDelimiter(String argString)
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
                //if not [, will be single delimiter
                if (argChars[2] != '[')
                {
                    customDelimiters.Add(argChars[2].ToString());
                    return customDelimiters;
                }
                //add each new delimiter, start over
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
