using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Interfaces;
using CustomMatrix.Matrix;

namespace CustomMatrix.Visitors
{
    /// <summary>
    /// Class extansion functionality hierarchy clases
    /// </summary>
    public static class MatrixExtansions
    {
        /// <summary>
        /// Extansion method for summ two matrix with element type T
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <param name="strategy">strategy summ two elements type T</param>
        /// <returns>result matrix with element type T</returns>
        public static SquareMatrix<T> Summ<T>(this BaseMatrix<T> first, BaseMatrix<T> second, ISummStrategy<T> strategy)
        {
            var visitor = new ComputeSummVisitor<T>(second, strategy);

            first.Accept(visitor);

            return visitor.SummResult;
        }
    }
}
