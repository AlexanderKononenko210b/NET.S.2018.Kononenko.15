using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Exceptions;
using CustomMatrix.Interfaces;

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

        public abstract T this[int indexRow, int indexColumn] { get; set; }

        #endregion

        #region Element change event

        /// <summary>
        /// Event where change the element in matrix
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs> MatrixChanged = delegate { };

        #endregion Element change event

        #region Protected members

        /// <summary>
        /// Method for call event type MatrixChanged
        /// </summary>
        /// <param name="info">info about event</param>
        protected virtual void OnMatrixChanged(MatrixChangedEventArgs info)
        {
            MatrixChanged(this, info);
        }

        /// <summary>
        /// Override method for check input matrix
        /// </summary>
        /// <returns>true if input matrix is valid</returns>
        protected abstract (bool, string) IsValidInputMatrix(T[,] inputMatrix);

        #endregion Protected members
    }
}
