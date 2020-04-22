using LibBaseSequence;

namespace HashTool
{
    public class Result :ResultBase
    {
        private string hashValue;
        public string GetHashValue() { return hashValue; }
        public void SetHashValue (string value) { hashValue = value; }

        protected override void InitCore ( )
        {
            SetHashValue("");
        }
    }
}
