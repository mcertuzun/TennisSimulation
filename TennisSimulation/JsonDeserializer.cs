using Newtonsoft.Json;
using System;
using System.IO;

namespace TournamentSimulation.Serializer
{
    public class JsonDeserializer<T> : IDeserializer<T>
    {
        private readonly string _jsonText;
        public JsonDeserializer(string jsonText)
        {
            this._jsonText = jsonText;
        }
        public T Deserialize()
        {
            try
            {
                T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(_jsonText));
                return data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Deserialization failed.", ex);
            }
        }

        public string GetFilePath( string file)
        {
            return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, "Data", file);
        }
    }
}