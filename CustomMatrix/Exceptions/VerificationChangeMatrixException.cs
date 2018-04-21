using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatrix.Exceptions
{
    [Serializable]
    public class VerificationChangeMatrixException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public VerificationChangeMatrixException()
        {
        }

        public VerificationChangeMatrixException(string message) : base(message)
        {
        }

        public VerificationChangeMatrixException(string message, Exception inner) : base(message, inner)
        {
        }

        protected VerificationChangeMatrixException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
