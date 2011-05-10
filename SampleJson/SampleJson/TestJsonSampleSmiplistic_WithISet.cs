using System.Collections.Generic;
using Newtonsoft.Json;
using SampleJson.JsonConverters;

namespace SampleJson
{
    public class TestJsonSampleSmiplistic_WithISet
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

            /*** ... Importnat part starts here ... ***/

            // Add converter for Sets            
            JsonSerializer serializer = convertSample.JsonSerializer;
            serializer.Converters.Add(new SetConverter());

            // The rest is normal also ...

            // Try to create new object from JSON text, using ISet for list of int
            var newObjectCopy = convertSample.GetObjectFromJson<ISet<int>>(jsonText);

            // See the output
            testHelper.WriteObjectToConsole(newObjectCopy);
        } 
    }
}