using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Krsak.Common.Extensions.Xml.Linq
{
	public static class XElementExtensions
	{
		private static readonly Dictionary<string, string> DicStrStrEmpty = new Dictionary<string, string>();
		/// <summary><see cref="XElement"/>からXPathを生成する。同一階層に同名要素が複数あるケースは未対応
		/// </summary>
		/// <param name="_this"></param>
		/// <param name="dicElemName_KeyAttrName"></param>
		/// <returns></returns>
		public static string GetXPath(this XElement _this, Dictionary<string, string> dicElemName_KeyAttrName = null)
		{
			var dic_elem_name__key_attr_name = dicElemName_KeyAttrName ?? DicStrStrEmpty;
			var elem_names = new List<string>();

			var elem = _this;
			while (elem != null) {
				string nmspace = elem.GetPrefixOfNamespace(elem.Name.Namespace);
				string elem_name = (string.IsNullOrEmpty(nmspace) ? "" : nmspace + ":") + elem.Name.LocalName;
				string xpath_elem_name = elem_name;
				string key_attr_name = null;
				if (dic_elem_name__key_attr_name.TryGetValue(elem_name, out key_attr_name)) {
					var attr = elem.Attribute(key_attr_name);
					if (attr != null) {
						xpath_elem_name += $"[@{attr.Name.LocalName}='{attr.Value}']";
					}
				}
				elem_names.Add(xpath_elem_name);
				elem = elem.Parent;
			}

			elem_names.Add(""); // ルートノード用
			return string.Join("/", ((IEnumerable<string>)elem_names).Reverse());
		}
	}
}
