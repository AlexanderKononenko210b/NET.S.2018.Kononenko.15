using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Matrix;

namespace CustomMatrix
{
    /// <summary>
    /// Class extansion functionality hierarchy clases
    /// </summary>
    public static class MatrixExtansions
    {
        /// <summary>
        /// Extansion method for summ two matrix with element type T
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns>result matrix with element type T</returns>
        public static BaseMatrix<T> Add<T>(this BaseMatrix<T> first, BaseMatrix<T> second)
        {
            if(first == null)
                throw new ArgumentNullException($"Argument {nameof(first)} is null");

            if (second == null)
                throw new ArgumentNullException($"Argument {nameof(second)} is null");

            if (first.Size != second.Size)
                throw new InvalidOperationException($"Size matrixs for add are not the same");

            BaseMatrix<T> result;

            try
            {
                result = Add((dynamic)first, (dynamic)second);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new NotSupportedException($"Type {nameof(T)} doesn`t support addition operation");
            }

            return result;
        }

        /// <summary>
        /// Add two square matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first square matrix</param>
        /// <param name="second">second square matrix</param>
        /// <returns>result square matrix</returns>
        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> first, SquareMatrix<T> second)
        {
            var resutMatrix = new SquareMatrix<T>(first.Size);

            for(int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add square and simmetric matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first square matrix</param>
        /// <param name="second">second simmetric matrix</param>
        /// <returns>result square matrix</returns>
        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> first, SimmetricSquareMatrix<T> second)
        {
            var resutMatrix = new SquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add simmetric and square matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first simmetric matrix</param>
        /// <param name="second">second square matrix</param>
        /// <returns>result square matrix</returns>
        private static SquareMatrix<T> Add<T>(this SimmetricSquareMatrix<T> first, SquareMatrix<T> second)
        {
            var resutMatrix = new SquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add square and diagonal matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first square matrix</param>
        /// <param name="second">second diagonal matrix</param>
        /// <returns>result square matrix</returns>
        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> first, DiagonalSquareMatrix<T> second)
        {
            var resutMatrix = new SquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    if(i == j)
                        resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add diagonal and square matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first diagonal matrix</param>
        /// <param name="second">second square matrix</param>
        /// <returns>result square matrix</returns>
        private static SquareMatrix<T> Add<T>(this DiagonalSquareMatrix<T> first, SquareMatrix<T> second)
        {
            var resutMatrix = new SquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add simmetric and diagonal matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first square matrix</param>
        /// <param name="second">second diagonal matrix</param>
        /// <returns>result square matrix</returns>
        private static SimmetricSquareMatrix<T> Add<T>(this SimmetricSquareMatrix<T> first, DiagonalSquareMatrix<T> second)
        {
            var resutMatrix = new SimmetricSquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    if (i == j)
                        resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add diagonal and simmetric matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first diagonal matrix</param>
        /// <param name="second">second simmetric matrix</param>
        /// <returns>result square matrix</returns>
        private static SimmetricSquareMatrix<T> Add<T>(this DiagonalSquareMatrix<T> first, SimmetricSquareMatrix<T> second)
        {
            var resutMatrix = new SimmetricSquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add diagonal and diagonal matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first diagonal matrix</param>
        /// <param name="second">second diagonal matrix</param>
        /// <returns>result square matrix</returns>
        private static DiagonalSquareMatrix<T> Add<T>(this DiagonalSquareMatrix<T> first, DiagonalSquareMatrix<T> second)
        {
            var resutMatrix = new DiagonalSquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    if (i == j)
                        resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }

        /// <summary>
        /// Add simmetric and simmetric matrix
        /// </summary>
        /// <typeparam name="T">type elements in matrix</typeparam>
        /// <param name="first">first simmetric matrix</param>
        /// <param name="second">second simmetric matrix</param>
        /// <returns>result square matrix</returns>
        private static SimmetricSquareMatrix<T> Add<T>(this SimmetricSquareMatrix<T> first, SimmetricSquareMatrix<T> second)
        {
            var resutMatrix = new SimmetricSquareMatrix<T>(first.Size);

            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    resutMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
                }
            }

            return resutMatrix;
        }
    }
}
