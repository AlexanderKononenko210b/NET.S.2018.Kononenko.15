using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix.Matrix;

namespace CustomMatrix.Test
{
    /// <summary>
    /// Helper for check result summ two matrix
    /// </summary>
    public class HelperForSumm<T>
    {
        public bool IsEqual(BaseMatrix<T> first, BaseMatrix<T> second)
        {
            var sizeMin = first.Size <= second.Size ? first.Size : second.Size;

            var equalityComparer = EqualityComparer<T>.Default;

            for (int i = 0; i < sizeMin; i++)
            {
                for (int j = 0; j < sizeMin; j++)
                    if (!equalityComparer.Equals(first[i, j], second[i, j]))
                            return false;
            }

            return true;
        }
    }
}
