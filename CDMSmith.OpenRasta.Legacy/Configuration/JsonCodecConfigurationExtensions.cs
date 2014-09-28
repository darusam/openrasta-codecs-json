using System;
using System.Collections.Generic;
using System.Text;
using OpenRasta.Configuration.Fluent;

namespace CDMSmith.OpenRasta.Legacy.Configuration
{
    public static class JsonCodecConfigurationExtensions
    {
        public static ICodecDefinition AsJsonData(this ICodecParentDefinition codecParent)
        {
            return codecParent.TranscodedBy<CDMSmith.OpenRasta.Legacy.Codecs.JsonCodec>(null);
        }
    }
}
