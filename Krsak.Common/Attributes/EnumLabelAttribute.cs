using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krsak.Common.Attributes
{
	/// <summary>列挙型の対象にラベルを付ける
	/// </summary>
	/// <remarks>
	/// <para>
	/// 参考文献
	/// <list type="bullet">
	///  <item>
	///   <term>【C#】Enumに文字列を持たせる | 技術日記</term>
	///   <description>
	///    <a href="http://skilllog.sitemix.jp/c/%E3%80%90c%E3%80%91enum%E3%81%AB%E6%96%87%E5%AD%97%E5%88%97%E3%82%92%E6%8C%81%E3%81%9F%E3%81%9B%E3%82%8B.html">
	///    http://skilllog.sitemix.jp/c/%E3%80%90c%E3%80%91enum%E3%81%AB%E6%96%87%E5%AD%97%E5%88%97%E3%82%92%E6%8C%81%E3%81%9F%E3%81%9B%E3%82%8B.html
	///    </a>
	///   </description>
	///  </item>
	/// </list>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code><![CDATA[
	/// enum hoge {
	/// 	[Label("label")]
	/// 	piyo,
	/// 	fuga,
	/// 	[Label("key_aaa", "label_aaa")]
	/// 	[Label("key_bbb", "label_bbb")]
	/// 	moke,
	/// }
	/// ]]></code>
	/// <code><![CDATA[
	/// var text_label1_1 = EnumLabelAttribute.GetLabel(hoge.piyo);                     // text_label1_1 = "label"
	/// var text_label2_1 = EnumLabelAttribute.GetLabel(hoge.fuga);                     // text_label2_1 = "fuga"
	/// var text_label1_2 = EnumLabelAttribute.GetLabel(hoge.piyo, true);               // text_label1_2 = "label"
	/// var text_label2_2 = EnumLabelAttribute.GetLabel(hoge.fuga, true);               // text_label2_2 = null
	/// var text_label3_1 = EnumLabelAttribute.GetLabel(hoge.moke, "key_aaa");          // text_label3_1 = "label_aaa"
	/// var text_label3_2 = EnumLabelAttribute.GetLabel(hoge.moke, "key_bbb");          // text_label3_2 = "label_bbb"
	/// var text_label3_3 = EnumLabelAttribute.GetLabel(hoge.moke, "key_ccc");          // text_label3_3 = "moke"
	/// var text_label3_4 = EnumLabelAttribute.GetLabel(hoge.moke, "key_ccc", true);    // text_label3_4 = null
	/// ]]></code>
	/// </example>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public class EnumLabelAttribute : Attribute
	{
		private string _Label;
		private string _Key;
		/// <summary>コンストラクタ。列挙型の値にラベルを付ける
		/// </summary>
		/// <param name="label">列挙型の値に付けるラベル</param>
		public EnumLabelAttribute(string label)
		{
			this._Label = label;
			this._Key = null;
		}
		/// <summary>コンストラクタ。列挙型の値にキーとラベルを付ける
		/// </summary>
		/// <param name="key">列挙型に付けるラベルのキー</param>
		/// <param name="label">列挙型の値に付けるラベル</param>
		public EnumLabelAttribute(string key, string label)
			: this(label)
		{
			this._Key = key;
		}

		/// <summary>ラベルを取得する。ラベルが設定されていない場合に取得できるラベルは、<paramref name="strict"/>の値によって変化する。
		/// </summary>
		/// <param name="value">列挙型の値</param>
		/// <param name="strict">
		///  ラベルが設定されていないときの戻り値を指定する。
		///  <list type="table">
		///   <listheader><item><paramref name="strict"/>の値</item><description>戻り値</description></listheader>
		///   <item><term>true</term><description>null</description></item>
		///   <item><term>false</term><description>列挙型の値そのものの名前文字列</description></item>
		///  </list>
		/// </param>
		/// <returns>
		///  <para>ラベルが設定されている場合、ラベルの文字列を取得する。</para>
		///  <para>ラベルが複数設定されている場合、最初に見つかったラベルの文字列を取得する。</para>
		///  <para>
		///   ラベルが設定されていない場合、<paramref name="strict"/>によって取得する値が変化する。
		///   詳細は<paramref name="strict"/>を参照のこと。
		///  </para>
		/// </returns>
		/// <example>
		/// <code><![CDATA[
		/// enum hoge {
		/// 	[Label("label")]
		/// 	piyo,
		/// 	huga,
		/// }
		/// var text_label1_1 = LabelAttribute.GetLabel(hoge.piyo);         // text_label1_1 = "label"
		/// var text_label2_1 = LabelAttribute.GetLabel(hoge.huga);         // text_label2_1 = "huga"
		/// var text_label1_2 = LabelAttribute.GetLabel(hoge.piyo, true);   // text_label1_2 = "label"
		/// var text_label2_2 = LabelAttribute.GetLabel(hoge.huga, true);   // text_label2_2 = null
		/// ]]></code>
		/// </example>
		public static string GetLabel(Enum value, bool strict = false)
		{
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			var attributes = (EnumLabelAttribute[])type.GetField(name).GetCustomAttributes(typeof(EnumLabelAttribute), false);

			string ret = null;
			if (attributes != null && attributes.Length > 0) {
				var wk = attributes.Where(x => string.IsNullOrEmpty(x._Key));
				ret = wk.FirstOrDefault()?._Label;
				if (string.IsNullOrEmpty(ret)) {
					ret = attributes.First()._Label;
				}
			}

			if (ret == null && !strict) ret = name;
			return ret;
		}
		/// <summary>キーを指定してラベルを取得する。ラベルが設定されていない場合に取得できるラベルは、<paramref name="strict"/>の値によって変化する。
		/// </summary>
		/// <param name="value">列挙型の値</param>
		/// <param name="key">キー</param>
		/// <param name="strict">
		///  ラベルが設定されていないときの戻り値を指定する。
		///  <list type="table">
		///   <listheader><item><paramref name="strict"/>の値</item><description>戻り値</description></listheader>
		///   <item><term>true</term><description>null</description></item>
		///   <item><term>false</term><description>列挙型の値そのものの名前文字列</description></item>
		///  </list>
		/// </param>
		/// <returns>
		///  <para>ラベルが設定されている場合、ラベルの文字列を取得する。</para>
		///  <para>
		///   ラベルが設定されていない場合、<paramref name="strict"/>によって取得する値が変化する。
		///   詳細は<paramref name="strict"/>を参照のこと。
		///  </para>
		/// </returns>
		/// <example>
		/// <code><![CDATA[
		/// enum hoge {
		/// 	[Label("key", "label")]
		/// 	piyo,
		/// 	huga,
		/// }
		/// var text_label0_1 = LabelAttribute.GetLabel(hoge.piyo);                 // text_label1_0 = "piyo"
		/// var text_label1_1 = LabelAttribute.GetLabel(hoge.piyo, "key");          // text_label1_1 = "label"
		/// var text_label2_1 = LabelAttribute.GetLabel(hoge.huga, "key");          // text_label2_1 = "huga"
		/// var text_label0_2 = LabelAttribute.GetLabel(hoge.piyo, true);           // text_label1_2 = null
		/// var text_label1_2 = LabelAttribute.GetLabel(hoge.piyo, "key", true);    // text_label1_2 = "label"
		/// var text_label2_2 = LabelAttribute.GetLabel(hoge.huga, "key", true);    // text_label2_2 = null
		/// ]]></code>
		/// </example>
		public static string GetLabel(Enum value, string key, bool strict = false)
		{
			if (string.IsNullOrEmpty(key)) {
				return GetLabel(value, strict);
			}
			var type = value.GetType();
			var name = Enum.GetName(type, value);
			var attributes = (EnumLabelAttribute[])type.GetField(name).GetCustomAttributes(typeof(EnumLabelAttribute), false);

			string ret = null;
			if (attributes != null && attributes.Length > 0) {
				foreach (var attr in attributes) {
					if (attr._Key == key) {
						ret = attr._Label;
						break;
					}
				}
			}

			if (ret == null && !strict) ret = name;
			return ret;
		}
	}
}
