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
    /// Constructor for create square matrix
    /// </summary>
    /// <typeparam name="T">type element square matrix</typeparam>
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        #region Field

        private T[,] matrix;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for create new square two range matrix
        /// </summary>
        /// <param name="size">size square matrix</param>
        public SquareMatrix(int size)
        {
            this.Size = size;

            this.matrix = new T[size, size];

            this.MatrixChanged += CheckChangeEventHandler;
        }

        /// <summary>
        /// Constructor for create new square two range matrix based on existing square matrix
        /// </summary>
        /// <param name="inputMatrix">input square matrix</param>
        public SquareMatrix(T[,] inputMatrix)
        {
            var verify = IsValidInputMatrix(inputMatrix);

            if (!verify.Item1)
                throw new BorderPropertyException(verify.Item2);

            this.Size = (int)Math.Sqrt(inputMatrix.Length);

            this.matrix = new T[Size, Size];

            Array.Copy(inputMatrix, matrix, matrix.Length);

            this.MatrixChanged += CheckChangeEventHandler;
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
            return matrix[indexRow, indexColumn];
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
            matrix[indexRow, indexColumn] = value;
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

            return (true, $"Input matrix {nameof(inputMatrix)} is valid");
        }
        
        /// <summary>
        /// Handler if event changed
        /// </summary>
        /// <param name="sender">object started event</param>
        /// <param name="info">info about event</param>
        protected void CheckChangeEventHandler(object sender, MatrixChangedEventArgs info)
        {
            PrintService.Print($"Square matrix was changed. Changed element row: {info.Row} column: {info.Column}");
        }

        /// <summary>
        /// Override method for check change matrix
        /// </summary>
        /// <param name="indexRow">index row for change</param>
        /// <param name="indexColumn">index column for change</param>
        /// <returns>true if index is valid</returns>
        protected override (bool, string) IsVerifyAccessIndex(int indexRow, int indexColumn)
        {
            if (indexRow > Size - 1 || indexRow < 0)
                return (false, $"Argument {nameof(indexRow)} is not valid");

            if (indexColumn > Size - 1 || indexColumn < 0)
                return (false, $"Argument {nameof(indexColumn)} is not valid");

            return (true, $"Argument {nameof(indexColumn)} and {nameof(indexRow)} is valid");
        }

        #endregion Protected members
    }
}
