<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="http://Microsoft.Samples.WindowsForms" >
<xsl:output omit-xml-declaration="yes" method="xml" indent="yes"/>

 <xsl:template match="@*|node()">
  <xsl:copy>
   <xsl:apply-templates select="@*|node()"/>
  </xsl:copy>
 </xsl:template>
 
 <xsl:template match="s:HighTemperature">
	 <xsl:copy>
	    <xsl:value-of select="round((. - 32) * 5 div 9)" />
	 </xsl:copy>
 </xsl:template>

 <xsl:template match="s:LowTemperature">
	 <xsl:copy>
	    <xsl:value-of select="round((. - 32) * 5 div 9)" />
	 </xsl:copy>
 </xsl:template>
</xsl:stylesheet>