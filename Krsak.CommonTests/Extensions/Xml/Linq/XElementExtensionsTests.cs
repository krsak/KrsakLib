using Microsoft.VisualStudio.TestTools.UnitTesting;
using Krsak.Common.Extensions.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Krsak.Common.Extensions.Xml.Linq.Tests
{
	[TestClass()]
	public class XElementExtensionsTests
	{
		[TestMethod()]
		[TestCategory("XElementExtensions")]
		public void GetXPathTest1()
		{
			string str_xml = @"
<Item id='xxx'>
  <i18n:text xml:lang='ja' xmlns:i18n='http://www.aras.com/I18N'>あああ</i18n:text>
  <i18n:text xml:lang='en' xmlns:i18n='http://www.aras.com/I18N'>aaa</i18n:text>
</Item>
";
			var doc = XDocument.Parse(str_xml);
			var nsmgr = new XmlNamespaceManager(new NameTable());
			nsmgr.AddNamespace("i18n", "http://www.aras.com/I18N");
			nsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
			var elem = doc.XPathSelectElement("/Item/i18n:text", nsmgr);
			var xpath = elem.GetXPath(new Dictionary<string, string>() { { "Item", "id" }, });

			xpath.Is(@"/Item[@id='xxx']/i18n:text");
		}

		[TestMethod()]
		[TestCategory("XElementExtensions")]
		public void GetXPathTest2()
		{
			string str_xml = @"
<AML>
<Item id='yyy'>
  <i18n:text xml:lang='ja' xmlns:i18n='http://www.aras.com/I18N'>あああ</i18n:text>
  <i18n:text xml:lang='en' xmlns:i18n='http://www.aras.com/I18N'>aaa</i18n:text>
</Item>
</AML>
";
			var doc = XDocument.Parse(str_xml);
			var nsmgr = new XmlNamespaceManager(new NameTable());
			nsmgr.AddNamespace("i18n", "http://www.aras.com/I18N");
			nsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
			var elem = doc.XPathSelectElement("/AML/Item/i18n:text", nsmgr);
			var xpath = elem.GetXPath(new Dictionary<string, string>() { { "Item", "id" }, });

			xpath.Is(@"/AML/Item[@id='yyy']/i18n:text");
		}

		[TestMethod()]
		[TestCategory("XElementExtensions")]
		public void GetXPathTest3()
		{
			string str_xml = @"
<AML>
<Item id='xxx'>
  <i18n:text xml:lang='ja' xmlns:i18n='http://www.aras.com/I18N'>あああ</i18n:text>
  <i18n:text xml:lang='en' xmlns:i18n='http://www.aras.com/I18N'>aaa</i18n:text>
  <Relationships>
   <Item id='yyy'>
	 <i18n:label xml:lang='ja' xmlns:i18n='http://www.aras.com/I18N'>いいい</i18n:label>
	 <i18n:label xml:lang='en' xmlns:i18n='http://www.aras.com/I18N'>iii</i18n:label>
	 <related_id>
	  <Item id='zzz'>
		<i18n:description xml:lang='ja' xmlns:i18n='http://www.aras.com/I18N'>ううう</i18n:description>
		<i18n:description xml:lang='en' xmlns:i18n='http://www.aras.com/I18N'>uuu</i18n:description>
	  </Item>
	 </related_id>
   </Item>
  </Relationships>
</Item>
</AML>
";
			var doc = XDocument.Parse(str_xml);
			var nsmgr = new XmlNamespaceManager(new NameTable());
			nsmgr.AddNamespace("i18n", "http://www.aras.com/I18N");
			nsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
			var elem = doc.XPathSelectElement("/AML/Item/Relationships/Item/related_id/Item/i18n:description", nsmgr);
			var xpath = elem.GetXPath(new Dictionary<string, string>() { { "Item", "id" }, });

			xpath.Is(@"/AML/Item[@id='xxx']/Relationships/Item[@id='yyy']/related_id/Item[@id='zzz']/i18n:description");
		}

	}
}
