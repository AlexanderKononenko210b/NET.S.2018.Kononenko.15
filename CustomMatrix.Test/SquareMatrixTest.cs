using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using CustomMatrix;
using CustomMatrix.Exceptions;
using CustomMatrix.Matrix;

namespace CustomMatrix.Test
{
    [TestFixture]
    public class SquareMatrixTest
    {
        /// <summary>
        /// Create instance typeof SquareMatrix using size
        /// </summary>
        [TestCase]
        public void SquareMatrix_Create_Instance_Using_Size()
        {
            var matrix = new SquareMatrix<int>(5);

            matrix[0, 0] = 5;

            Assert.AreEqual(5, matrix[0, 0]);
        }

        /// <summary>
        /// Create instance typeof SquareMatrix using exiting matrix
        /// </summary>
        [TestCase]
        public void SquareMatrix_Create_Instance_Valid_Input_Matrix_()
        {
            int[,] inputArray = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            var matrix = new SquareMatrix<int>(inputArray);

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                    Assert.AreEqual(inputArray[i, j], matrix[i, j]);
            }
        }

        /// <summary>
        /// Create instance typeof SquareMatrix using exiting matrix expected BorderPropertyException
        /// </summary>
        [TestCase]
        public void SquareMatrix_Create_Instance_Input_Matrix_Expected_BorderPropertyException_If_Argument_Null()
        {
            int[,] inputArray = null;

            Assert.Throws<BorderPropertyException>(() => new SquareMatrix<int>(inputArray));
        }

        /// <summary>
        /// Create instance typeof SquareMatrix using exiting matrix expected BorderPropertyException
        /// </summary>
        [TestCase]
        public void SquareMatrix_Create_Instance_Input_Matrix_Expected_BorderPropertyException()
        {
            int[,] inputArray = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 }, { 3, 5, 2 } };

            Assert.Throws<BorderPropertyException>(() => new SquareMatrix<int>(inputArray));
        }

        /// <summary>
        /// Change instance typeof SquareMatrix expected IndexAccessException
        /// </summary>
        [TestCase]
        public void SquareMatrix_Change_Element_Expected_IndexAccessException_If_IndexRow_Less_0()
        {
            int[,] inputArray = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            var matrix = new SquareMatrix<int>(inputArray);

            Assert.Throws<IndexAccessException>(() => matrix[-1, 4] = 5);
        }

        /// <summary>
        /// Change instance typeof SquareMatrix expected IndexAccessException
        /// </summary>
        [TestCase]
        public void SquareMatrix_Change_Element_Expected_IndexAccessException_If_IndexColumn_Less_0()
        {
            int[,] inputArray = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            var matrix = new SquareMatrix<int>(inputArray);

            Assert.Throws<IndexAccessException>(() => matrix[0, -1] = 5);
        }
    }
}
