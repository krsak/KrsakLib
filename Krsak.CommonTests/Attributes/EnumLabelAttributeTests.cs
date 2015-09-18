using Microsoft.VisualStudio.TestTools.UnitTesting;
using Krsak.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krsak.Common.Attributes.Tests
{
	[TestClass()]
	public class EnumLabelAttributeTests
	{
		public TestContext TestContext { get; set; }

		enum Hoge
		{
			[EnumLabel("label")]
			piyo,
			fuga,
			[EnumLabel("key_aaa", "label_aaa")]
			[EnumLabel("key_bbb", "label_bbb")]
			[EnumLabel("label_ccc")]
			moke,
			[EnumLabel("key_aaa", "label_aaa")]
			[EnumLabel("key_bbb", "label_bbb")]
			kepi,
		}
		[TestMethod()]
		[TestCategory("NoKey")]
		[TestCase(false)]
		[TestCase(true)]
		public void GetLabelTest_NoKey_piyo()
		{
			TestContext.Run((bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.piyo, strict).Is("label");
			});
		}
		[TestMethod()]
		[TestCategory("NoKey")]
		[TestCase(false)]
		[TestCase(true)]
		public void GetLabelTest_NoKey_fuga()
		{
			TestContext.Run((bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.fuga, strict).Is(strict ? null : nameof(Hoge.fuga));
			});
		}
		[TestMethod()]
		[TestCategory("NoKey")]
		[TestCase(false)]
		[TestCase(true)]
		public void GetLabelTest_NoKey_moke()
		{
			TestContext.Run((bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.moke, strict).Is("label_ccc");
			});
		}
		[TestMethod()]
		[TestCategory("NoKey")]
		[TestCase(false)]
		[TestCase(true)]
		public void GetLabelTest_NoKey_kepi()
		{
			TestContext.Run((bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.kepi, strict).Is("label_aaa");
			});
		}

		[TestMethod()]
		[TestCategory("Key")]
		[TestCase("key_aaa", false)]
		[TestCase("key_bbb", false)]
		[TestCase("key_ccc", false)]
		[TestCase("", false)]
		[TestCase("key_aaa", true)]
		[TestCase("key_bbb", true)]
		[TestCase("key_ccc", true)]
		[TestCase("", true)]
		public void GetLabelTest_Key_piyo()
		{
			TestContext.Run((string key, bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.piyo, key, strict).Is(string.IsNullOrEmpty(key) ? "label" : (strict ? null : nameof(Hoge.piyo)));
			});
		}
		[TestMethod()]
		[TestCategory("Key")]
		[TestCase("key_aaa", false)]
		[TestCase("key_bbb", false)]
		[TestCase("key_ccc", false)]
		[TestCase("", false)]
		[TestCase("key_aaa", true)]
		[TestCase("key_bbb", true)]
		[TestCase("key_ccc", true)]
		[TestCase("", true)]
		public void GetLabelTest_Key_fuga()
		{
			TestContext.Run((string key, bool strict) =>
			{
				EnumLabelAttribute.GetLabel(Hoge.fuga, key, strict).Is(strict ? null : nameof(Hoge.fuga));
			});
		}
		[TestMethod()]
		[TestCategory("Key")]
		[TestCase("key_aaa", false)]
		[TestCase("key_bbb", false)]
		[TestCase("key_ccc", false)]
		[TestCase("", false)]
		[TestCase("key_aaa", true)]
		[TestCase("key_bbb", true)]
		[TestCase("key_ccc", true)]
		[TestCase("", true)]
		public void GetLabelTest_Key_moke()
		{
			TestContext.Run((string key, bool strict) =>
			{
				string label;
				switch (key) {
				case "key_aaa": label = "label_aaa"; break;
				case "key_bbb": label = "label_bbb"; break;
				case "key_ccc": label = strict ? null : nameof(Hoge.moke); break;
				default: label = "label_ccc"; break;
				}
				EnumLabelAttribute.GetLabel(Hoge.moke, key, strict).Is(label);
			});
		}
		[TestMethod()]
		[TestCategory("Key")]
		[TestCase("key_aaa", false)]
		[TestCase("key_bbb", false)]
		[TestCase("key_ccc", false)]
		[TestCase("", false)]
		[TestCase("key_aaa", true)]
		[TestCase("key_bbb", true)]
		[TestCase("key_ccc", true)]
		[TestCase("", true)]
		public void GetLabelTest_Key_kepi()
		{
			TestContext.Run((string key, bool strict) =>
			{
				string label;
				switch (key) {
				case "key_aaa": label = "label_aaa"; break;
				case "key_bbb": label = "label_bbb"; break;
				case "key_ccc": label = strict ? null : nameof(Hoge.kepi); break;
				default: label = "label_aaa"; break;
				}
				EnumLabelAttribute.GetLabel(Hoge.kepi, key, strict).Is(label);
			});
		}
	}
}