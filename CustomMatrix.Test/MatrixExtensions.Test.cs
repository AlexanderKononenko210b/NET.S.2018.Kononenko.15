using System;
using CustomMatrix.Matrix;
using NUnit.Framework;
using Microsoft.CSharp.RuntimeBinder;

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
        public void SquareMatrix_Add_SquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SquareMatrix<int>(inputMatrixFirst);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 12, 2 }, { 10, 4, 18 }, { 6, 10, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type SquareMatrix
        /// </summary>
        [TestCase]
        public void SquareMatrix_Add_SquareMatrix_Expected_RuntimeBinderException()
        {
            bool[,] inputMatrixFirst = { { true, false, true }, { true, false, true }, { true, false, true } };

            BaseMatrix<bool> firstMatrix = new SquareMatrix<bool>(inputMatrixFirst);

            BaseMatrix<bool> secondMatrix = new SquareMatrix<bool>(inputMatrixFirst);

            Assert.Throws<RuntimeBinderException>(() => firstMatrix.Add(secondMatrix));
        }

        /// <summary>
        /// Test Summ two matrix type SimmetricSquareMatrix
        /// </summary>
        [TestCase]
        public void SimmetricSquareMatrix_Add_SimmetricSquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 4, 6 }, { 4, 4, 10 }, { 6, 10, 4 } };

            var resultHelper = new SimmetricSquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Add_DiagonalSquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            BaseMatrix<int> firstMatrix = new DiagonalSquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new DiagonalSquareMatrix<int>(inputMatrixFirst);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 0, 0 }, { 0, 4, 0 }, { 0, 0, 4 } };

            var resultHelper = new DiagonalSquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SimmetricSquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Add_SimmetricSquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            int[,] inputMatrixSecond = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            BaseMatrix<int> firstMatrix = new DiagonalSquareMatrix<int>(inputMatrixSecond);

            BaseMatrix<int> secondMatrix = new SimmetricSquareMatrix<int>(inputMatrixFirst);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 2, 3 }, { 2, 4, 5 }, { 3, 5, 4 } };

            var resultHelper = new SimmetricSquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SquareMatrix
        /// </summary>
        [TestCase]
        public void DiagonalSquareMatrix_Add_SquareMatrix()
        {
            int[,] inputMatrixSecond = { { 4, default(int), default(int) },
                { default(int), 2, default(int) }, { default(int), default(int), 2 } };

            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new DiagonalSquareMatrix<int>(inputMatrixSecond);

            BaseMatrix<int> secondMatrix = new SquareMatrix<int>(inputMatrixFirst);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 6, 1 }, { 5, 4, 9 }, { 3, 5, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }

        /// <summary>
        /// Test Summ two matrix type DiagonalSquareMatrix and SquareMatrix
        /// </summary>
        [TestCase]
        public void SimmetricSquareMatrix_Add_SquareMatrix()
        {
            int[,] inputMatrixFirst = { { 4, 6, 1 }, { 5, 2, 9 }, { 3, 5, 2 } };

            int[,] inputMatrixSecond = { { 4, 2, 3 }, { 2, 2, 5 }, { 3, 5, 2 } };

            BaseMatrix<int> firstMatrix = new SquareMatrix<int>(inputMatrixFirst);

            BaseMatrix<int> secondMatrix = new SimmetricSquareMatrix<int>(inputMatrixSecond);

            var resultSumm = firstMatrix.Add(secondMatrix);

            int[,] resultMatrix = { { 8, 8, 4 }, { 7, 4, 14 }, { 6, 10, 4 } };

            var resultHelper = new SquareMatrix<int>(resultMatrix);

            var helper = new HelperForSumm<int>();

            Assert.IsTrue(helper.IsEqual(resultHelper, resultSumm));
        }
    }
}
