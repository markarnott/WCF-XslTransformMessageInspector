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

using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace XslTransformMessageInspector
{
    public class XslTransformBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ClientMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new DispatchMessageInspector());
        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        { }
    }
}
