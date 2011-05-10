using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleJson
{
    public class TestDataHelper
    {
        // Simple loop to fill in our data structure with dummy data
        public SortedDictionary<string, ISet<int>> CreateSampleObject()
        {
            var dataToWrite =
                new SortedDictionary<string, ISet<int>>();

            for (int number = 1; number <= 9; number++)
            {
                // This adds new entry, the key is a number saved as string
                // The value is a list of numbers from 1 to given number.
                //  The list is inserted into a HashSet. 
                //      The numbers are unique already but for testing
                // So, example: for number = 3 we get 
                //      Key = "3"
                //      Value = new HashSet() {1, 2, 3}

                dataToWrite.Add(number.ToString(),
                         new HashSet<int>(Enumerable.Range(1, number)));
            }

            return dataToWrite;
        }

        
        /*** ... Writing Value To JSON String... ***/

        public void WriteJsonToConsole(string json)
        {
            Console.WriteLine("Json:");
            Console.WriteLine(json);
            Console.WriteLine();
        }


        /*** ... Output Read Value ... ***/

        public void WriteObjectToConsole<TSetOfInt32>
            (SortedDictionary<string, TSetOfInt32> dataFromJsonString)
            // Made the type an argument so that I can use HashSet or ISet
            where TSetOfInt32 : ISet<int>
        {
            // Lets output the objects
            Console.WriteLine("Objects:");

            foreach (var entry in dataFromJsonString)
            {
                // Example entry with key 3 will output -> "3: 1, 2, 3"
                string entryText =
                    entry.Key + ": " + string.Join(", ", entry.Value);

                Console.WriteLine(entryText);
            }
        }
    }
}