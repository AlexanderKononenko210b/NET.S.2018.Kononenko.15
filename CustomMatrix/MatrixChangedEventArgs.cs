using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatrix
{
    /// <summary>
    /// Class for information about event change element in matrix
    /// </summary>
    public class MatrixChangedEventArgs : EventArgs
    {
        public string TypeMatrix { get; }

        public int Row { get; }

        public int Column { get; }

        public MatrixChangedEventArgs(string typeMatrix, int row, int column)
        {
            this.TypeMatrix = typeMatrix;

            this.Row = row;

            this.Column = column;
        }
    }
}
