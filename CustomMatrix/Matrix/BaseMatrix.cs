using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Exceptions;

namespace CustomMatrix.Matrix
{
    /// <summary>
    /// Abstract base class describing two rang matrix and have common fields, propertys, methods for inharitance classes
    /// </summary>
    /// <typeparam name="T">type element in matrix</typeparam>
    public abstract class BaseMatrix<T>
    {
        #region Fields

        private int size;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Get and private set size square matrix
        /// </summary>
        public int Size
        {
            get => size;

            protected set
            {
                if (value <= 0)
                    throw new BorderPropertyException($"Size is not valid");

                size = value;
            }
        }

        public int Length => size * size;

        public T this[int indexRow, int indexColumn]
        {
            get
            {
                if (indexRow > Size - 1 || indexRow < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexRow)} is not valid");

                if (indexColumn > Size - 1 || indexColumn < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexColumn)} is not valid");

                return GetByIndex(indexRow, indexColumn);
            }
            set
            {
                if (indexRow > Size - 1 || indexRow < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexRow)} is not valid");

                if (indexColumn > Size - 1 || indexColumn < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexColumn)} is not valid");

                SetByIndex(indexRow, indexColumn, value);

                OnMatrixChanged(new MatrixChangedEventArgs(this.GetType().ToString(), indexRow, indexColumn));
            }
        }

        #endregion

        #region Element change event

        /// <summary>
        /// Event where change the element in matrix
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs> MatrixChanged;

        #endregion Element change event

        #region Protected members

        /// <summary>
        /// Method for call event type MatrixChanged
        /// </summary>
        /// <param name="info">info about event</param>
        protected virtual void OnMatrixChanged(MatrixChangedEventArgs info)
        {
            MatrixChanged?.Invoke(this, info);
        }

        /// <summary>
        /// Get element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <returns>element in matrix</returns>
        protected abstract T GetByIndex(int indexRow, int indexColumn);

        /// <summary>
        /// Set element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <param name="value">column of matrix</param>
        /// <returns>element in matrix</returns>
        protected abstract void SetByIndex(int indexRow, int indexColumn, T value);

        /// <summary>
        /// Override method for check input matrix
        /// </summary>
        /// <returns>true if input matrix is valid</returns>
        protected abstract (bool, string) IsValidInputMatrix(T[,] inputMatrix);

        #endregion
    }
}
