namespace SampleJson
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create HashSet test
            
            //var sampleTester = new TestJsonSampleSmiplistic_WithHashSet();
            
            // Create ISet Test

            var sampleTester = new TestJsonSampleSmiplistic_WithISet();


            // Run Test

            sampleTester.TestReadWriteJson();
        }
    }
}