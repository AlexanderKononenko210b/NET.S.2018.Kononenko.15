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
    /// Visitor class for summ two matrix
    /// </summary>
    /// <typeparam name="T">type element in matrix</typeparam>
    public class ComputeSummVisitor<T> : MatrixVisitor<T>
    {
        #region Fields

        private BaseMatrix<T> second;

        private Func<T, T, T> summStrategy;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Get or Private Set result matrix of summ
        /// </summary>
        public SquareMatrix<T> SummResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructor for class ComputeSummVisitor
        /// </summary>
        /// <param name="second">second matrix for summ</param>
        /// <param name="summInterfaceStrategy">strategy summ two object type T using interface</param>
        public ComputeSummVisitor(BaseMatrix<T> second, ISummStrategy<T> summInterfaceStrategy)
        {
            this.second = second;

            this.summStrategy = summInterfaceStrategy.Summ;
        }

        /// <summary>
        /// Constructor for class ComputeSummVisitor
        /// </summary>
        /// <param name="second">second matrix for summ</param>
        /// <param name="summDelegateStrategy">strategy summ two object type T using delegate</param>
        public ComputeSummVisitor(SquareMatrix<T> second, Func<T, T, T> summDelegateStrategy)
        {
            this.second = second;

            this.summStrategy = summDelegateStrategy;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Method Visit in common
        /// </summary>
        /// <param name="matrix">instance class for summ operation</param>
        public void DynamicVisit(BaseMatrix<T> matrix) => Visit((dynamic) matrix);

        protected override SquareMatrix<T> Visit(SquareMatrix<T> square) => Summ(square);

        protected override SquareMatrix<T> Visit(SimmetricSquareMatrix<T> simmetric) => Summ(simmetric);

        protected override SquareMatrix<T> Visit(DiagonalSquareMatrix<T> diagonal) => Summ(diagonal);

        #endregion

        #region Private method

        /// <summary>
        /// Helper method with logic summ two matrix
        /// </summary>
        /// <param name="first">first matrix for summ</param>
        /// <returns>result matrix type SquareMatrix<typeparam name="T"></typeparam></returns>
        private SquareMatrix<T> Summ(BaseMatrix<T> first)
        {
            if (first == null)
                throw new ArgumentNullException($"Argument {nameof(first)} is null");

            var sizeResultMatrix = first.Size > second.Size ? first.Size : second.Size;

            var sizeMin = first.Size <= second.Size ? first.Size : second.Size;

            SummResult = new SquareMatrix<T>(sizeResultMatrix);

            for (int i = 0; i < sizeMin; i++)
            {
                for (int j = 0; j < sizeMin; j++)
                {
                    SummResult[i, j] = summStrategy(first[i, j], second[i, j]);
                }
            }

            return SummResult;
        }

        #endregion
    }
}
