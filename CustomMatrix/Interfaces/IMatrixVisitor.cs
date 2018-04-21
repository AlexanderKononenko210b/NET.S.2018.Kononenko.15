using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Matrix;

namespace CustomMatrix.Interfaces
{
    /// <summary>
    /// Interface for implement pattern Visitor
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public interface IMatrixVisitor<T>
    {
        SquareMatrix<T> Visit(SquareMatrix<T> square);

        SquareMatrix<T> Visit(SimmetricSquareMatrix<T> simmetric);

        SquareMatrix<T> Visit(DiagonalSquareMatrix<T> diagonal);
    }
}
