using System;
using System.Collections.Generic;
using System.Web;
using OpenRasta.Codecs;
using OpenRasta.Web;
using OpenRasta.TypeSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CDMSmith.OpenRasta.Legacy.Codecs
{
    [MediaType("application/json", "json")]
    public class JsonCodec : IMediaTypeReader, IMediaTypeWriter
    {
        public object Configuration { get; set; }

        
        public object ReadFrom(IHttpEntity request, IType destinationType, string destinationName)
        {
            if (destinationType.StaticType == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                string toConvert = string.Empty;
                using(System.IO.StreamReader reader = new System.IO.StreamReader(request.Stream))
                {
                    toConvert = reader.ReadToEnd();
                }
                object toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject(toConvert, destinationType.StaticType);
                return toReturn;
            }
        }

        public void WriteTo(object entity, IHttpEntity response, string[] codecParameters)
        {
            if (entity == null)
            {
                return;
            }
            /*
            ICollection<JsonConverter> converters;
            if(Configuration == null)
            {
                converters = new JsonConverter[] { new IsoDateTimeConverter() };
            }
            else
            {
                converters = Configuration as ICollection<JsonConverter>;
                if(converters == null)
                {
                    converters = new JsonConverter[] { new IsoDateTimeConverter() };
                }
            }
            */
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new IsoDateTimeConverter());
            //foreach(JsonConverter converter in converters)
            //{
            //    serializer.Converters.Add(converter);
            //}
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(response.Stream))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, entity);
                    jw.Flush();
                    jw.Close();
                }

            }
            
        }
    }
}