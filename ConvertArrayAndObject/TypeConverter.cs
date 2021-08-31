using ConvertArrayAndObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyType
{
    
    public class TypeConverter
    {
        public Data data { set; get; }
        public List<Data> enumerable { set; get; }

        public static implicit operator TypeConverter(Data data)
        {
            return new TypeConverter(data);
        }
        public static implicit operator Data(TypeConverter info)
        {
            return info.data;
        }
        public TypeConverter(Data data)
        {
            this.data = data;
        }
        public TypeConverter(List<Data> enumerable)
        {
            this.enumerable = enumerable;
        }

        public static implicit operator TypeConverter(List<Data> data)
        {
            return new TypeConverter(data);
        }
        public static implicit operator List<Data>(TypeConverter info)
        {
            return info.enumerable;
        }
        public TypeConverter()
        {
                
        }
    }
}
