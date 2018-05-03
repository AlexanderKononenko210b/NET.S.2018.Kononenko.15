using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatrix.Exceptions
{
    [Serializable]
    public class BorderPropertyException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public BorderPropertyException()
        {
        }

        public BorderPropertyException(string message) : base(message)
        {
        }

        public BorderPropertyException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BorderPropertyException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
