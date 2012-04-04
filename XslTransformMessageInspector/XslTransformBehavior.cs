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
using System.IO;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace XslTransformMessageInspector
{
    public class XslTransformBehavior : IEndpointBehavior
    {
        private string _styleSheetPath;
        private XmlReader _styleSheetXRdr;

        public XslTransformBehavior(string styleSheetPath)
        {
            _styleSheetPath = styleSheetPath;
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MessageInspectors(LoadStyleSheet(_styleSheetPath)));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MessageInspectors(LoadStyleSheet(_styleSheetPath)));
        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        { }

        public XmlReader LoadStyleSheet(string styleSheetPath)
        {
            if (_styleSheetXRdr != null && _styleSheetPath == styleSheetPath)
                return _styleSheetXRdr;

            if(File.Exists(styleSheetPath))
            {
                _styleSheetXRdr = XmlReader.Create(styleSheetPath);
                _styleSheetPath = styleSheetPath;
            }
            else
            {
                Debug.WriteLine("XslTransformBehavior - could not load stylesheet");
                Debug.WriteLine("\t" + styleSheetPath);
            }
            return _styleSheetXRdr;
        }
    }
}
