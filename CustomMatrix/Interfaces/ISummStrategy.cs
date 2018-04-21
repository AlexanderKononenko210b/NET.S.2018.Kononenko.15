using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatrix.Interfaces
{
    /// <summary>
    /// Interface for strategy summ two object type T
    /// </summary>
    /// <typeparam name="T">type summ instance</typeparam>
    public interface ISummStrategy<T>
    {
        T Summ(T first, T second);
    }
}
