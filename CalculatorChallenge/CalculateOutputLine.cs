using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorChallenge
{
    public class CalculateOutputLine
    {
        public String Formula { get; set; } 

        public List<Int32> Nums { get; set; }

        public int Operation { get; set; }
        public int Total { get; set; }
        public CalculateOutputLine(List<Int32>nums, int operation)
        {
            this.Nums = nums;
            Operation = operation;
            switch (operation)
            {
                case 1:
                    AddTotals();
                    break;
                case 2:
                    SubtractTotals();
                    break;
                case 3:
                    MultiplyTotals();
                    break;
                case 4:
                    DivideTotals();
                    break;
            }
                
        }

        private void AddTotals()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Nums.Count; i++) 
            {
                sb.Append("(" + Nums[i] + ")");
                sb.Append("+");
                Total += Nums[i];
            }
            sb.Remove(sb.Length - 1, 1);
            Formula = sb.ToString();
        }
        private void SubtractTotals()
        {
            Total = Nums[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Nums.Count; i++)
            {
                sb.Append("(" + Nums[i] + ")");
                sb.Append("-");
                if (i > 0)
                {
                    Total -= Nums[i];
                }
            }
            sb.Remove(sb.Length - 1, 1);
            Formula = sb.ToString();
        }
        private void MultiplyTotals()
        {
            Total = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Nums.Count; i++)
            {
                sb.Append("(" + Nums[i] + ")");
                sb.Append("*");
                Total *= Nums[i];
            }
            sb.Remove(sb.Length - 1, 1);
            Formula = sb.ToString();
        }
        private void DivideTotals()
        {
            Total = Nums[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Nums.Count; i++)
            {
                sb.Append("(" + Nums[i] + ")");
                sb.Append("/");
                if (i > 0)
                {
                    Total /= Nums[i];
                }
            }
            sb.Remove(sb.Length - 1, 1);
            Formula = sb.ToString();
        }
    }
}
