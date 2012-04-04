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
using System.Text;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;
using XslTransformMessageInspector;


namespace XslTransformMessageInspectorTests
{
    [TestFixture]
    public class XslTransformBehaviorTests
    {
        [Test]
        [Ignore]
        public void should_load_styleSheet()
        {
            var xBehavior = new XslTransformBehavior("");

            XmlReader xrdr = xBehavior.LoadStyleSheet("");
        }
    }
}
