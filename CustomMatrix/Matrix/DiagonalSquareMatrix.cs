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

            this.MatrixChanged += CheckChangeEventHandler;
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

            this.MatrixChanged += CheckChangeEventHandler;
        }

        #endregion Constructors

        #region Public Api

        /// <summary>
        /// Indexer for access element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <returns>element in matrix</returns>
        public override T this[int indexRow, int indexColumn]
        {
            get
            {
                var verify = IsVerifyAccessIndex(indexRow, indexColumn);

                if (!verify.Item1)
                    throw new IndexAccessException(verify.Item2);

                if (indexRow != indexColumn)
                    return default(T);

                return matrix[indexRow];
            }
            set
            {
                var verify = IsVerifyAccessIndex(indexRow, indexColumn);

                if (!verify.Item1)
                    throw new IndexAccessException(verify.Item2);

                if (indexRow != indexColumn)
                    throw new IndexAccessException($"Argument {nameof(indexColumn)} and {nameof(indexRow)} have to equals");

                matrix[indexRow] = value;

                OnMatrixChanged(new MatrixChangedEventArgs(indexRow, indexColumn));
            }
        }

        #endregion

        #region Protected and private members

        /// <summary>
        /// Handler if event changed
        /// </summary>
        /// <param name="sender">object started event</param>
        /// <param name="info">info about event</param>
        private void CheckChangeEventHandler(object sender, MatrixChangedEventArgs info)
        {
            PrintService.Print($"Diagonal square matrix was changed. Changed element row: {info.Row} column: {info.Column}");
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

        /// <summary>
        /// Override method for check change matrix
        /// </summary>
        /// <param name="indexRow">index row for change</param>
        /// <param name="indexColumn">index column for change</param>
        /// <returns>true if index is valid</returns>
        private (bool, string) IsVerifyAccessIndex(int indexRow, int indexColumn)
        {
            if (indexRow > Size - 1 || indexRow < 0)
                return (false, $"Argument {nameof(indexRow)} is not valid");

            if (indexColumn > Size - 1 || indexColumn < 0)
                return (false, $"Argument {nameof(indexColumn)} is not valid");

           return (true, $"Argument {nameof(indexColumn)} and {nameof(indexRow)} is valid");
        }

        #endregion Protected and private members
    }
}
