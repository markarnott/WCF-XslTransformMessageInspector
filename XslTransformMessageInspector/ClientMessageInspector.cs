﻿#region Copyright
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

using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace XslTransformMessageInspector
{
    public class ClientMessageInspector :  IClientMessageInspector
    {
        public ClientMessageInspector() 
        {}

        public ClientMessageInspector(XmlReader xrdr)
        {
            TransformStyleSheet = xrdr;
        }

        public XmlReader TransformStyleSheet { get; set; }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Debug.WriteLine("XslTransformMessageInspector.ClientMessageInspector.AfterReceiveReply()");
            if (TransformStyleSheet != null)
            {
                XslTransformer.transform(ref reply, TransformStyleSheet);
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    }
}
