using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Exceptions;
using CustomMatrix.Interfaces;

namespace CustomMatrix.Matrix
{
    /// <summary>
    /// Class representation simmetric square matrix
    /// </summary>
    public class SimmetricSquareMatrix<T> : BaseMatrix<T>
    {
        #region Field

        private T[][] matrix;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for create new square two range matrix
        /// </summary>
        /// <param name="size">size square matrix</param>
        public SimmetricSquareMatrix(int size)
        {
            this.Size = size;

            this.matrix = new T[Size][];

            for(int i = 0; i < Size; i++)
                matrix[i] = new T[Size - i];
        }

        /// <summary>
        /// Constructor for create new square two range matrix based on existing square matrix
        /// </summary>
        /// <param name="inputMatrix">existing square matrix</param>
        public SimmetricSquareMatrix(T[,] inputMatrix)
        {
            var verify = IsValidInputMatrix(inputMatrix);

            if (!verify.Item1)
                throw new BorderPropertyException(verify.Item2);

            this.Size = (int)Math.Sqrt(inputMatrix.Length);

            this.matrix = new T[Size][];

            for (int i = 0; i < Size; i++)
                matrix[i] = new T[Size - i];

            for (int i = 0; i <= inputMatrix.GetUpperBound(0); i++)
                for (int j = i; j <= inputMatrix.GetUpperBound(1); j++)
                    matrix[i][j - i] = inputMatrix[i, j];
        }

        #endregion Constructors

        #region Protected and private members

        /// <summary>
        /// Get element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <returns>element in matrix</returns>
        protected override T GetByIndex(int indexRow, int indexColumn)
        {
                if (indexRow == indexColumn)
                    return matrix[indexRow][0];

                if (indexRow < indexColumn)
                    return matrix[indexRow][indexColumn - indexRow];

                return matrix[indexColumn][indexRow - indexColumn];
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
            if (indexRow == indexColumn)
                matrix[indexRow][0] = value;

            else if (indexRow < indexColumn)
            {
                matrix[indexRow][indexColumn - indexRow] = value;

                matrix[indexColumn - indexRow][indexRow] = value;
            }
            else
            {
                matrix[indexColumn][indexRow - indexColumn] = value;

                matrix[indexRow - indexColumn][indexColumn] = value;
            }
        }

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
                for (int j = i + 1; j <= inputMatrix.GetUpperBound(1); j++)
                    if (!equalityComparer.Equals(inputMatrix[i, j], inputMatrix[j, i]))
                        return (false, $"Input matrix {nameof(inputMatrix)} is not simmetric");

            return (true, $"Input matrix {nameof(inputMatrix)} is valid");
        }

        #endregion
    }
}
