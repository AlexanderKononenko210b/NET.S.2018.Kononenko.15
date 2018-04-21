﻿using System;
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
        #region Constructors

        /// <summary>
        /// Constructor for create new simmetric square matrix using size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SimmetricSquareMatrix(int size) : base(size) { }

        /// <summary>
        /// Constructor for create new simmetric square matrix using size and existing matrix
        /// </summary>
        /// <param name="inputMatrix">existing matrix</param>
        public SimmetricSquareMatrix(T[,] inputMatrix) : base(inputMatrix) { }

        #endregion Constructors

        #region Public Api

        /// <summary>
        /// Override method Accept
        /// </summary>
        /// <param name="visitor"></param>
        public override void Accept(IMatrixVisitor<T> visitor)
        {
            visitor.Visit(this);
        }

        #endregion

        #region Protected members

        /// <summary>
        /// Handler if event changed
        /// </summary>
        /// <param name="sender">object started event</param>
        /// <param name="info">info about event</param>
        protected override void CheckChangeEventHandler(object sender, MatrixChangedEventArgs info)
        {
            var printService = new PrintService();

            printService.Print($"Simmetric square matrix was changed. Changed element row: {info.Row} column: {info.Column}");
        }

        /// <summary>
        /// Override method for check input matrix
        /// </summary>
        /// <returns>true if input matrix is valid</returns>
        protected override bool IsValidInputMatrix(T[,] inputMatrix)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            for (int i = 0; i < inputMatrix.GetUpperBound(0); i++)
            {
                for (int j = i + 1; j <= inputMatrix.GetUpperBound(1); j++)
                {
                    if (!equalityComparer.Equals(inputMatrix[i, j], inputMatrix[j, i]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override method for check change matrix
        /// </summary>
        /// <param name="row">index row for change</param>
        /// <param name="column">index column for change</param>
        /// <param name="obj">object for insert</param>
        /// <returns>true if change is valid</returns>
        protected override bool IsVerificationChangeMatrix(int row, int column, T obj)
        {
            if(obj == null)
                throw new ArgumentNullException($"Argument {nameof(obj)} is null");

            if (row != column)
            {
                var equalityComparer = EqualityComparer<T>.Default;

                if (!equalityComparer.Equals(this[column, row], obj))
                    return false;
            }

            return true;
        }

        #endregion Protected members
    }
}