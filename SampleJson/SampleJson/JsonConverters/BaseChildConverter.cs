using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SampleJson.JsonConverters
{
    public class BaseChildConverter<TBase, TChild> : CustomCreationConverter<TBase>
        where TChild : TBase, new()
    {
        /// <summary>
        /// Very straight forward. Just create new instance of child type
        /// </summary>
        public override TBase Create(Type objectType)
        {
            return new TChild();
        }
    }


    /// <summary>
    /// Example on how to use BaseChildConverter
    /// </summary>
    internal static class BaseChildConverterUsage
    {
        private static void Example_ForCodeReadingOnly()
        {
            JsonSerializer jsonSerializer =
                JsonSerializer.Create(new JsonSerializerSettings());

            var converter =
                new BaseChildConverter<ISet<int>, HashSet<int>>();

            jsonSerializer.Converters.Add(converter);

            // Then we go play with ..
            //  jsonSerializer.Deserialize(...)
        }
    }
}