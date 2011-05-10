using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SampleJson
{
    public class JsonConverterSample
    {
        // The main JSON.NET class that does all the work
        public JsonSerializer JsonSerializer { get; private set; }

        /*** ... Initializing ... ***/

        public JsonConverterSample()
        {
           // Create the main class in JSON.NET to use in read / write
           //  Giving mandatory settings (that easy to create default one)
            JsonSerializer =
                JsonSerializer.Create(new JsonSerializerSettings());
        }

        /*** ... Writin JSON ... ***/

        public string ConvertDataToJson(object objectToWrite)
        {
            // This is .NET class. It simulates Text Reader
            //   just like those you use to 
            //      write to file or HTTP response in ASP.NET
            // But just writes to a string.
            var outputWriter = new StringWriter();

            // Create a serializer, 
            //  give it some mandatory settings that we don't need to change
            // Then write the dataToWrite to the text writer.
            JsonSerializer.Serialize(outputWriter, objectToWrite);

            return outputWriter.ToString();
        }

        /*** ... Reading JSON ... ***/

        public SortedDictionary<string, TSetOfInt32>
            GetObjectFromJson<TSetOfInt32>(string jsonText)
            // This is NOT required for JSON.NET
            // It only allows me to replace HashSet with ISet later
            where TSetOfInt32 : ISet<int>
        {
            // We created a reader similar to our writer, 
            //  but the library has diferent ways of reading 
            //      parts of JSON text, depth of properties, etc...
            //  So, we create a JSON reader from library, it's also easy!
            var reader = new JsonTextReader(new StringReader(jsonText));


            // Reading is easy. Define what type we expect, 
            //  that's SortedDictionary<string, HashSet<int>>
            // Amd pass the text to read.
            return JsonSerializer
                .Deserialize<SortedDictionary<string, TSetOfInt32>>(reader);
        }
    }
}