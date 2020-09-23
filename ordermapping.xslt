<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="Order">
	<CustomerOrder>
		<OrderId>
			<xsl:value-of select="Id" />
		</OrderId>
		<CustName>
			<xsl:value-of select="Name" />
		</CustName>
		<Desc>
			<xsl:text>No desc yet</xsl:text>
		</Desc>
	</CustomerOrder>
</xsl:template>

</xsl:stylesheet>