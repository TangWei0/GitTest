namespace Log.Tests
{
    public class TestBase
    {
        protected static string GetTestName(int count)
        {
            return $"TestCase_{count + 1:D4}";
        }
    }
}
