using System;
using CustomMatrix.Exceptions;
using CustomMatrix.Matrix;
using NUnit.Framework;

namespace CustomMatrix.Test
{
    [TestFixture]
    public class DiagonalSquareMatrixTest
    {
        /// <summary>
        /// Create instance typeof DiagonalSquareMatrix using size
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Create_Instance_Using_Size()
        {
            var matrix = new DiagonalSquareMatrix<int>(5);

            matrix[0, 0] = 5;

            Assert.AreEqual(5, matrix[0, 0]);

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                    if (i != j)
                        Assert.AreEqual(default(int), matrix[i,j]);
            }
        }

        /// <summary>
        /// Create instance typeof DiagonalSquareMatrix using exiting matrix
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Create_Instance_Valid_Input_Matrix_()
        {
            int[,] inputArray = { { 4, default(int), default(int) }, 
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            var matrix = new DiagonalSquareMatrix<int>(inputArray);

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                    Assert.AreEqual(inputArray[i, j], matrix[i, j]);
            }
        }

        /// <summary>
        /// Create instance typeof DiagonalSquareMatrix using exiting matrix expected ArgumentNullException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Create_Instance_Input_Matrix_Expected_ArgumentNullException()
        {
            int[,] inputArray = null;

            Assert.Throws<ArgumentNullException>(() => new DiagonalSquareMatrix<int>(inputArray));
        }

        /// <summary>
        /// Create instance typeof DiagonalSquareMatrix using exiting matrix expected BorderPropertyException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Create_Instance_Input_Matrix_Expected_BorderPropertyException()
        {
            int[,] inputArray = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 }, { 3, 5, 2 } };

            Assert.Throws<BorderPropertyException>(() => new DiagonalSquareMatrix<int>(inputArray));
        }

        /// <summary>
        /// Create instance typeof DiagonalSquareMatrix using exiting matrix expected BorderPropertyException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Create_Instance_Input_Matrix_Expected_BorderPropertyException_If_Specific_Requared_Not_Performed()
        {
            int[,] inputArray = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            Assert.Throws<BorderPropertyException>(() => new DiagonalSquareMatrix<int>(inputArray));
        }

        /// <summary>
        /// Change instance typeof SquareMatrix expected ArgumentOutOfRangeException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Change_Element_Expected_ArgumentOutOfRangeException_If_IndexRow_Less_0()
        {
            int[,] inputArray = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            var matrix = new DiagonalSquareMatrix<int>(inputArray);

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[-1, 4] = 5);
        }

        /// <summary>
        /// Change instance typeof SquareMatrix expected ArgumentOutOfRangeException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Change_Element_Expected_ArgumentOutOfRangeException_If_IndexColumn_Less_0()
        {
            int[,] inputArray = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            var matrix = new DiagonalSquareMatrix<int>(inputArray);

            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[0, -1] = 5);
        }

        /// <summary>
        /// Change instance typeof SquareMatrix expected InvalidOperationException
        /// </summary>
        [TestCase]
        public void DiagonalMatrix_Change_Element_Expected_InvalidOperationException_If_Value_Violates_Requirements_Insertion()
        {
            int[,] inputArray = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            var matrix = new DiagonalSquareMatrix<int>(inputArray);

            Assert.Throws<InvalidOperationException>(() => matrix[1, 2] = 4);
        }
    }
}
