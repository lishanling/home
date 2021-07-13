using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace web_home.Unitl
{
    public static class ObjectExtension
    {
        public static string Serializer(this Object obj)
        {
            return obj.Serializer(NullValueHandling.Include, Formatting.Indented);
        }
        public static string Serializer(this Object obj,NullValueHandling nullvalueHading, Formatting formatting)
        {
            string serialize;
            if (obj is string)
            {
                serialize = obj.ToString();
            }
            else
            {
                JsonSerializerSettings setting = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = formatting,
                    Converters = new List<JsonConverter>{
                        new IsoDateTimeConverter { DateTimeFormat="yyyy-MM-dd HH :mmLss"},
                        //new DecimalConverter()
                    }
                };
                serialize = JsonConvert.SerializeObject(obj, null, setting);
            }
            return serialize;
        }
    }
}