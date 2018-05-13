using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix;
using CustomMatrix.Matrix;

namespace CustomMatrixConsole.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new MatrixChangeListener();

            var squareMatrix = new SquareMatrix<int>(5);
            squareMatrix.MatrixChanged += listener.CheckChangeEventHandler;
            squareMatrix[1, 1] = 5;

            var simmetricSquareMatrix = new SimmetricSquareMatrix<int>(5);
            simmetricSquareMatrix.MatrixChanged += listener.CheckChangeEventHandler;
            simmetricSquareMatrix[1, 1] = 5;

            var diagonalSquareMatrix = new DiagonalSquareMatrix<int>(5);
            diagonalSquareMatrix.MatrixChanged += listener.CheckChangeEventHandler;
            diagonalSquareMatrix[1, 1] = 5;
        }
    }
}
