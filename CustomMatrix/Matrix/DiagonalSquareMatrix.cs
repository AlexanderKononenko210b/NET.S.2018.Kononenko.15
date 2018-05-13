using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Exceptions;

namespace CustomMatrix.Matrix
{
    /// <summary>
    /// Class representation diagonal square matrix
    /// </summary>
    public class DiagonalSquareMatrix<T> : BaseMatrix<T>
    {
        #region Field

        private T[] matrix;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for create new square two range matrix
        /// </summary>
        /// <param name="size">size square matrix</param>
        public DiagonalSquareMatrix(int size)
        {
            this.Size = size;

            this.matrix = new T[Size];
        }

        /// <summary>
        /// Constructor for create new square two range matrix based on existing square matrix
        /// </summary>
        /// <param name="inputMatrix">existing square matrix</param>
        public DiagonalSquareMatrix(T[,] inputMatrix)
        {
            var verify = IsValidInputMatrix(inputMatrix);

            if (!verify.Item1)
                throw new BorderPropertyException(verify.Item2);

            Size = (int)Math.Sqrt(inputMatrix.Length);

            matrix = new T[Size];

            for (int i = 0; i <= inputMatrix.GetUpperBound(0); i++)
            {
                matrix[i] = inputMatrix[i, i];
            }
        }

        #endregion Constructors

        #region Public Api

        /// <summary>
        /// Get element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <returns>element in matrix</returns>
        protected override T GetByIndex(int indexRow, int indexColumn)
        {
            if (indexRow != indexColumn)
                return default(T);

            return matrix[indexRow];
        }

        /// <summary>
        /// Set element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <param name="value">column of matrix</param>
        /// <returns>element in matrix</returns>
        protected override void SetByIndex(int indexRow, int indexColumn, T value)
        {
            if (indexRow != indexColumn)
                throw new IndexAccessException($"Argument {nameof(indexColumn)} and {nameof(indexRow)} have to equals");

            matrix[indexRow] = value;
        }

        #endregion

        #region Protected and private members

        /// <summary>
        /// Override method for check input matrix
        /// </summary>
        /// <returns>true if input matrix is valid</returns>
        protected override (bool, string) IsValidInputMatrix(T[,] inputMatrix)
        {
            if (inputMatrix == null)
                return (false, $"Argument {nameof(inputMatrix)} is null");

            if (inputMatrix.GetUpperBound(0) != inputMatrix.GetUpperBound(1))
                return (false, $"Input matrix {nameof(inputMatrix)} is not square");

            var equalityComparer = EqualityComparer<T>.Default;

            for (int i = 0; i < inputMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= inputMatrix.GetUpperBound(1); j++)
                {
                    if(i != j)
                        if (!equalityComparer.Equals(inputMatrix[i, j], default(T)))
                            return (false, $"Input matrix {nameof(inputMatrix)} is not simmetric");
                }
            }

            return (true, $"Input matrix {nameof(inputMatrix)} is valid");
        }

        #endregion Protected and private members
    }
}
