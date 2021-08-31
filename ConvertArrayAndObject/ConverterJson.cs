using ConvertArrayAndObject;
using MyType;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Converter
{

    public class PersonConverter : JsonCreationConverter<Data, List<Data>, TypeConverter>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override List<Data> CreateArray(Type objectType, JToken jObject)
        {
            return new List<Data>();
        }

        protected override Data CreateObject(Type objectType, JToken jObject)
        {
            return new Data();
        }

        protected override object PackArray<R>(List<Data> obj)
        {
            return  new TypeConverter(obj);
        }

        protected override object PackObj<T>(Data obj)
        {
            return new TypeConverter(obj);
        }
    }

    public abstract class JsonCreationConverter<Obj, Array, BaseType> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract Obj CreateObject(Type objectType, JToken jObject);
        protected abstract Array CreateArray(Type objectType, JToken jObject);

        protected abstract object PackObj<T>(Obj obj);
        protected abstract object PackArray<R>(Array obj);

        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseType).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            JToken jObject = JToken.Load(reader);
            if (jObject is JObject)
            {
                var res = CreateObject(objectType, jObject);
                serializer.Populate(jObject.CreateReader(), res);
                return PackObj<Obj>(res);
            }
            else if (jObject is JArray)
            {
                var res = CreateArray(objectType, jObject);
                serializer.Populate(jObject.CreateReader(), res);
                return PackArray<Array>(res);

            }
            else throw new Exception();
        }
    }
}
