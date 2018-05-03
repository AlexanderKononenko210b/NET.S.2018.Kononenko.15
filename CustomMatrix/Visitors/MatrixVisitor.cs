using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Matrix;

namespace CustomMatrix.Visitors
{
    /// <summary>
    /// Abstract class for implement pattern Visitor
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public abstract class MatrixVisitor<T>
    {
        public void DynamicVisitor(BaseMatrix<T> matrix)
            => Visit((dynamic) matrix);

        protected abstract SquareMatrix<T> Visit(SquareMatrix<T> square);

        protected abstract SquareMatrix<T> Visit(SimmetricSquareMatrix<T> simmetric);

        protected abstract SquareMatrix<T> Visit(DiagonalSquareMatrix<T> diagonal);
    }
}
