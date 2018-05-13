using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMatrix;

namespace CustomMatrixConsole.Test
{
    /// <summary>
    /// Listener change matrix event
    /// </summary>
    public class MatrixChangeListener
    {
        /// <summary>
        /// Handler if event changed
        /// </summary>
        /// <param name="sender">object started event</param>
        /// <param name="info">info about event</param>
        public void CheckChangeEventHandler(object sender, MatrixChangedEventArgs info)
        {
            PrintService.Print($"Matrix type {info.TypeMatrix} was changed. Changed element row: {info.Row} column: {info.Column}");
        }
    }
}
