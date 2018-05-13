using System;
using CustomMatrix.Matrix;
using CustomMatrix.Visitors;
using NUnit.Framework;

namespace CustomMatrix.Test
{
    /// <summary>
    /// Class for test extension method for summ two matrix
    /// </summary>
    [TestFixture]
    public class MatrixExtensions
    {
        /// <summary>
        /// Test Summ two matrix type SquareMatrix
        /// </summary>
        [TestCase]
        public void SquareMatrix_Summ_Two_Instances()
        {
            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SquareMatrix<int>(inputMatrixFirst);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 12, 2 }, { 10, 4, 18 }, { 6, 10, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type SimmetricSquareMatrix
        /// </summary>
        [TestCase]
        public void SimmetricSquareMatrix_Summ_Two_Instances()
        {
            int[,] inputMatrixFirst = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 4, 6 }, { 4, 4, 10 }, { 6, 10, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Summ_Two_Instances()
        {
            int[,] inputMatrixFirst = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            BaseMatrix<int> firstMatrix = new DiagonalSquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new DiagonalSquareMatrix<int>(inputMatrixFirst);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 0, 0 }, { 0, 4, 0 }, { 0, 0, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SimmetricSquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Summ_SimmetricSquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            int[,] inputMatrixSecond = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            BaseMatrix<int> firstMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new DiagonalSquareMatrix<int>(inputMatrixSecond);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 2, 3 }, { 2, 4, 5 }, { 3, 5, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Summ_SquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            int[,] inputMatrixSecond = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            BaseMatrix<int> firstMatrix = new SquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new DiagonalSquareMatrix<int>(inputMatrixSecond);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 6, 1 }, { 5, 4, 9 }, { 3, 5, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SquareMatrix
        /// </summary>
        [TestCase]
        public void SimmetricSquareMatrix_Summ_SquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            int[,] inputMatrixSecond = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SimmetricSquareMatrix<int>(inputMatrixSecond);

            var strategy = new IntSummStrategy();

            var resultSumm = firstMatrix.Add(secondMatrix, strategy);

            int[,] resultMatrix = { { 8, 8, 4 }, { 7, 4, 14 }, { 6, 10, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }
    }
}
