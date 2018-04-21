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
        public int Row { get; }

        public int Column { get; }

        public MatrixChangedEventArgs(int row, int column)
        {
            this.Row = row;

            this.Column = column;
        }
    }
}
