using Newtonsoft.Json;
using OopFundamentals.Models;

namespace OopFundamentals.DocumentStorages
{
    internal static class SerializationHelper
    {
        public static IDocument? Deserialize(string path, Type docType)
        {
            JsonSerializer serializer = new();

            using StreamReader sr = new(path);
            using JsonReader reader = new JsonTextReader(sr);

            var document = (IDocument?)serializer.Deserialize(reader, docType);

            sr.Close();

            return document;
        }
    }
}
