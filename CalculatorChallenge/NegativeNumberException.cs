using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    [Serializable]
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {

        }
        public NegativeNumberException(String message) : base(message){

        }

        public static NegativeNumberException Return(List<Int32> nums)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Int32 num in nums)
            {
                sb.Append(String.Format($"Negative number {num} was found"));
            }

            return new NegativeNumberException(sb.ToString());
        }
    }
}
