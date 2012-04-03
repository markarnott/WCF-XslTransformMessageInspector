#region Copyright
/**************************************
Copyright 2012 Mark Arnott

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
**************************************/
#endregion

using System.IO;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Xsl;

namespace XslTransformMessageInspector
{
    public class XslTransformer 
    {

        public static void TransformMessage(ref Message message, XmlReader styleSheet)
        {
            if (message.IsEmpty || message.IsFault)
                return;

            XmlReader xrdr = Transform(message.GetReaderAtBodyContents(), styleSheet);

            Message xformedMsg = Message.CreateMessage(message.Version, null, xrdr);
            xformedMsg.Headers.CopyHeadersFrom(message.Headers);
            xformedMsg.Properties.CopyProperties(message.Properties);
            message = xformedMsg;
        }

        public static XmlReader Transform(XmlReader input, XmlReader styleSheet)
        {
            var xsl = new XslCompiledTransform();
            xsl.Load(styleSheet);

            Stream memStr = new MemoryStream();
            XmlWriter xWriter = XmlWriter.Create(memStr);

            xsl.Transform(input, xWriter);

            memStr.Position = 0;

            XmlReader xrdr = XmlReader.Create(memStr);
            xrdr.MoveToContent();
            xWriter.Close();
            return xrdr;
        }
    }
}
