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

using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace XslTransformMessageInspector
{
    /// <summary>
    /// Required to enable the behavior with configuration
    /// </summary>
    public class BehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(XslTransformBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new XslTransformBehavior(StyleSheetPath);
        }

        [ConfigurationProperty("styleSheetPath", DefaultValue = "XslTransformMessageInspector.xsl", IsRequired = false)]
        public string StyleSheetPath
        {
            get { return base["styleSheetPath"].ToString(); }
            set { base["styleSheetPath"] = value; }
        }

    }
}
