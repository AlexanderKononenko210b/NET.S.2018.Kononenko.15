using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Interfaces;

namespace CustomMatrix.Test
{
    /// <summary>
    /// Class implement strategy summ two object type T
    /// </summary>
    public class IntSummStrategy : ISummStrategy<int>
    {
        public int Summ(int first, int second)
        {
            int summ;

            checked
            {
                summ = first + second;
            }

            return summ;
        }
    }
}
