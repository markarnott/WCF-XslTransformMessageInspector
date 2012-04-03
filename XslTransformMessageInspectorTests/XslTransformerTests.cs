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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;

namespace XslTransformMessageInspectorTests
{
    [TestFixture]
    public class XslTransformer
    {
private const string xslTemplate =
@"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:t=""http://WcfXformTest.Example.Org"" >
<xsl:output omit-xml-declaration=""yes"" method=""xml"" indent=""yes""/>

 <xsl:template match=""@*|node()"">
  <xsl:copy>
   <xsl:apply-templates select=""@*|node()""/>
  </xsl:copy>
 </xsl:template>
 
 <xsl:template match=""t:Response"">
	 <xsl:comment>This is a test</xsl:comment>
	 <xsl:copy>
	    <xsl:value-of select=""."" />
	 </xsl:copy>
 </xsl:template>
</xsl:stylesheet>";

private const string inputData =
@"<TimeOfDayResponse xmlns=""http://WcfXformTest.Example.Org"">
  <TimeOfDayResult xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    <Response>Good day to you sir.</Response>
    <TheTimeIs>2012-03-23T14:33:37.2464016-04:00</TheTimeIs>
  </TimeOfDayResult>
</TimeOfDayResponse>";

        private XmlReader styleSheet;
        private XmlReader input;

        [TestFixtureSetUp]
        public void Setup()
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xslTemplate));
            styleSheet = XmlReader.Create(ms);

            MemoryStream ms2 = new MemoryStream(Encoding.UTF8.GetBytes(inputData));
            input = XmlReader.Create(ms2);
        }

        [Test]
        public void should_transform_input()
        {
            XmlReader xrdr = XslTransformMessageInspector.XslTransformer.Transform(input, styleSheet);

            string transformedOutput = xrdr.ReadOuterXml();
            transformedOutput.Trim().Should().StartWith("<TimeOfDayResponse");
            transformedOutput.Should().Contain("This is a test");
        }

        //TODO test TransformMessage
    }
}
