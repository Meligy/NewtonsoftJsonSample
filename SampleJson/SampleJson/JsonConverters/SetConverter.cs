using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace SampleJson.JsonConverters
{
    /// <summary>
    /// Using this way we are creating one converter per type
    /// So, we need to have new SetConverter) etc
    /// Which is not optimal of course.
    /// </summary>
    public class SetConverter : CustomCreationConverter<IEnumerable>
    {
        public override bool CanConvert(Type objectType)
        {
            // We check whether the IEnumerable passed is actually an ISet<>
            return objectType.IsInterface &&
                   objectType.GetGenericTypeDefinition() == typeof (ISet<>);
        }

        /// <summary>
        /// We check for IEnumerable because it is the only non-generic
        ///     interface that ISet<> implements, so we don't have to
        ///     create SetConverter<int>, SetConverter<string>, etc..|
        /// </summary>
        public override IEnumerable Create(Type objectType)
        {
            // Assuming ISet<???>, we want to get this ??? part
            var elementTypes = objectType.GetGenericArguments();

            // We need an HashSet<???>, we get that type first
            var hashSetType = typeof (HashSet<>)
                .MakeGenericType(elementTypes);

            // Then create an instance of it using reflection
            return (IEnumerable)Activator.CreateInstance(hashSetType);
        }
    }
}