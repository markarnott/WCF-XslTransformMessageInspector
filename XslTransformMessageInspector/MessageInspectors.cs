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

using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace XslTransformMessageInspector
{
    public class MessageInspectors : IClientMessageInspector, IDispatchMessageInspector
    {
        public MessageInspectors() 
        {}

        public MessageInspectors(XmlReader xrdr)
        {
            _styleSheet = xrdr;
        }

        private static XmlReader _styleSheet;
        public XmlReader StyleSheet
        {
            get { return _styleSheet; } 
            set { _styleSheet = value; }
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (StyleSheet == null)
            {
                Debug.WriteLine("XslTransformMessageInspector.MessageInspectors.AfterReceiveReply - Error: No StyleSheet loaded");
                return;
            }
            Debug.WriteLine("XslTransformMessageInspector.MessageInspectors.AfterReceiveReply()");
            XslTransformer.TransformMessage(ref reply, StyleSheet);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel chl, InstanceContext ctx)
        {
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (StyleSheet == null)
            {
                Debug.WriteLine("XslTransformMessageInspector.MessageInspectors.BeforeSendReply - Error: No StyleSheet loaded");
                return;
            }
            Debug.WriteLine("XslTransformMessageInspector.MessageInspectors.BeforeSendReply()");
            XslTransformer.TransformMessage(ref reply, StyleSheet);
        }
    }
}
