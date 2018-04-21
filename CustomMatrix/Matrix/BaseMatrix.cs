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
    /// Abstract base class describing two rang matrix and have common fields, propertys, methods for inharitance classes
    /// </summary>
    /// <typeparam name="T">type element in matrix</typeparam>
    public abstract class BaseMatrix<T>
    {
        #region Fields

        private T[,] baseMatrix;

        private int size;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Get and private set size square matrix
        /// </summary>
        public int Size
        {
            get => size;

            private set
            {
                if (value <= 0)
                    throw new BorderPropertyException($"Size of matrix was more than 0");

                size = value;
            }
        }

        public int Length => size * size;

        /// <summary>
        /// Indexer for access element in matrix
        /// </summary>
        /// <param name="indexRow">row of matrix</param>
        /// <param name="indexColumn">column of matrix</param>
        /// <returns>element in matrix</returns>
        public T this[int indexRow, int indexColumn]
        {
            get
            {
                if (indexRow > size - 1 || indexRow < 0 )
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexRow)} is not valid");

                if (indexColumn > size - 1 || indexColumn < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexColumn)} is not valid");

                return baseMatrix[indexRow, indexColumn];
            }
            set
            {
                if (indexRow > size - 1 || indexRow < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexRow)} is not valid");

                if (indexColumn > size - 1 || indexColumn < 0)
                    throw new ArgumentOutOfRangeException($"Argument {nameof(indexColumn)} is not valid");

                if(!IsVerificationChangeMatrix(indexRow, indexColumn, value))
                    throw new InvalidOperationException($"Value for insert in matrix is not valid");
                
                baseMatrix[indexRow, indexColumn] = value;

                OnMatrixChanged(new MatrixChangedEventArgs(indexRow, indexColumn));
            }
        }

        #endregion

        #region Element change event

        /// <summary>
        /// Event where change the element in matrix
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs> MatrixChanged = delegate { };

        #endregion Element change event

        #region Constructors

        /// <summary>
        /// Constructor for create new square two range matrix
        /// </summary>
        /// <param name="size">size square matrix</param>
        protected BaseMatrix(int size)
        {
            Size = size;

            baseMatrix = new T[size, size];

            MatrixChanged += CheckChangeEventHandler;
        }

        /// <summary>
        /// Constructor for create new square two range matrix based on existing square matrix
        /// </summary>
        /// <param name="inputSquareMatrix">existing square matrix</param>
        protected BaseMatrix(T[,] inputSquareMatrix)
        {
            if(inputSquareMatrix == null)
                throw new ArgumentNullException($"Argument {nameof(inputSquareMatrix)} is null");

            if(inputSquareMatrix.GetUpperBound(0) != inputSquareMatrix.GetUpperBound(1))
                throw new BorderPropertyException($"Input matrix {nameof(inputSquareMatrix)} is not square");

            if(!IsValidInputMatrix(inputSquareMatrix))
                throw new BorderPropertyException($"Input matrix {nameof(inputSquareMatrix)} is not valid");

            Size = (int)Math.Sqrt(inputSquareMatrix.Length);

            baseMatrix = new T[size, size];

            if (size <= inputSquareMatrix.GetUpperBound(0))
                Array.Copy(inputSquareMatrix, baseMatrix, baseMatrix.Length);
            else
                Array.Copy(inputSquareMatrix, baseMatrix, inputSquareMatrix.Length);

            MatrixChanged += CheckChangeEventHandler;
        }

        #endregion Constructors

        #region Public API

        /// <summary>
        /// Method Accept for grow up functionality
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(IMatrixVisitor<T> visitor);

        #endregion

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
        /// Handler if event changed
        /// </summary>
        /// <param name="sender">object started event</param>
        /// <param name="info">info about event</param>
        protected abstract void CheckChangeEventHandler(object sender, MatrixChangedEventArgs info);

        /// <summary>
        /// Override method for check input matrix
        /// </summary>
        /// <returns>true if input matrix is valid</returns>
        protected abstract bool IsValidInputMatrix(T[,] inputMatrix);

        /// <summary>
        /// Abstract method for check change matrix
        /// </summary>
        /// <param name="row">index row for change</param>
        /// <param name="column">index column for change</param>
        /// <param name="obj">object for insert</param>
        /// <returns>true if change is valid</returns>
        protected abstract bool IsVerificationChangeMatrix(int row, int column, T obj);

        #endregion Protected members
    }
}
