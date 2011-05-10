using System.Collections.Generic;

namespace SampleJson
{
    public class TestJsonSampleSmiplistic_WithHashSet
    {
        /// <summary>
        /// Here is how we'll do the test
        /// </summary>
        public void TestReadWriteJson()
        {
            var testHelper = new TestDataHelper();
            var convertSample = new JsonConverterSample();

            var testObject = testHelper.CreateSampleObject();

            // Try to get JSON text
            string jsonText = convertSample.ConvertDataToJson(testObject);

            // See the output
            testHelper.WriteJsonToConsole(jsonText);

            // Try to create new object from JSON text, using HAshSet for list of int
            var newObjectCopy = convertSample.GetObjectFromJson<HashSet<int>>(jsonText);

            // See the output
            testHelper.WriteObjectToConsole(newObjectCopy);
        }
    }
}