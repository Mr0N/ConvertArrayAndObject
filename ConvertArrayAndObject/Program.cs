using Converter;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace ConvertArrayAndObject
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new PersonConverter());
            string jsonObj = "{\"data\":{\"Name\":\"Mr.N.\"}}";
            string jsonArray = "{\"data\":[]}";
            var obj = JsonConvert.DeserializeObject<Test>(jsonObj, jsonSettings);
            var arrays = JsonConvert.DeserializeObject<Test>(jsonArray, jsonSettings);
            Console.ReadKey();
        }
    }
}
