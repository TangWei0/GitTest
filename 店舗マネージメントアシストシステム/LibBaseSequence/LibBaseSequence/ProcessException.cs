using System;

namespace LibBaseSequence
{
    public class ProcessException :Exception
    {
        private const string overflowMessage = "プロセス異常発生";

        public ProcessException (string auxMessage) :
            base(string.Format("{0} - {1}", overflowMessage, auxMessage)) { }

        public ProcessException (string auxMessage, Exception inner) :
            base(string.Format("{0} - {1}", overflowMessage, auxMessage), inner) { }
        
        public void View ( )
        {
            Console.WriteLine(Message);
            Console.WriteLine(StackTrace);
        }
    }
}
