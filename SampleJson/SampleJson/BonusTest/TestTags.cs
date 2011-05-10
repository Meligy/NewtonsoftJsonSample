using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SampleJson.BonusTest
{

    // This is a bonus for those who like to check the code.
    // Nothing special, just a hierarchy of objects different than other one.
    // This is the original 'dirty' test, so, set low expectations already ;)
    
    // To Try it out, in Main() method, try: BonusTest.TestTags.Apply();
    
    // Tell me you found it on my blog!

    public class TestTags
    {
        public static void Apply()
        {
            var child = new TagObject()
                            {
                                Id = 1,
                                Type = "1",
                                Children =
                                    {
                                        new TagObject()
                                            {
                                                Id = 11,
                                                Type = "1.1",
                                                Children =
                                                    {
                                                        new TagObject()
                                                            {
                                                                Id = 21,
                                                                Type = "2.1"
                                                            }
                                                    }
                                            },
                                        new TagObject()
                                            {
                                                Id = 12,
                                                Type = "1.2",
                                                Children =
                                                    {
                                                        new TagObject()
                                                            {
                                                                Id = 21,
                                                                Type = "2.1"
                                                            }
                                                    }
                                            }
                                    }
                            };

            var writer = new StringWriter();

            JsonSerializer.Create(new JsonSerializerSettings() { })
                .Serialize(writer, child);
            
            Console.WriteLine(writer.ToString());
            var newChild = JsonSerializer
                .Create(new JsonSerializerSettings())
                .Deserialize<TagObject>(new JsonTextReader(new StringReader(writer.ToString())));

            Console.WriteLine(newChild.Children.First().Id == child.Children.First().Id);
        }

        private class TagObject
        {
            public string Title { get; set; }
            public int Id { get; set; }
            public string Type { get; set; }
            public List<TagObject> Children { get; set; }

            public TagObject()
            {
                Children = new List<TagObject>();
            }
        }
    }
}