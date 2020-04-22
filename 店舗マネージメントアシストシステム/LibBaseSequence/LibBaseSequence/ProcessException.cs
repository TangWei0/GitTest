using System;
using System.Collections.Generic;
using System.Text;

namespace LibBaseSequence
{
    public class ProcessException : Exception
    {
        const string overflowMessage = "プロセス異常発生";

        public ProcessException (string auxMessage, Exception inner) :
            base(String.Format("{0} - {1}", overflowMessage, auxMessage), inner) { }
    }
}
