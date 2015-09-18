using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Krsak.Common.Collections
{
	/// <summary><see cref="System.Collections.ObjectModel.ObservableCollection{T}"/>の非同期版
	/// </summary>
	/// <typeparam name="T">要素の型</typeparam>
	/// <remarks>
	/// <para>
	/// 参考文献
	/// <list type="bullet">
	///  <item>
	///   <term>[C#][WPF] ObservableCollectionを非同期で利用する際</term>
	///   <description>
	///    <a href="http://d.hatena.ne.jp/dreammind/20110108/1294420640">
	///    http://d.hatena.ne.jp/dreammind/20110108/1294420640
	///    </a>
	///   </description>
	///  </item>
	///  <item>
	///   <term>Have worker thread update ObservableCollection that is bound to a ListCollectionView</term>
	///   <description>
	///    <a href="http://geekswithblogs.net/NewThingsILearned/archive/2008/01/16/have-worker-thread-update-observablecollection-that-is-bound-to-a.aspx">
	///    http://geekswithblogs.net/NewThingsILearned/archive/2008/01/16/have-worker-thread-update-observablecollection-that-is-bound-to-a.aspx
	///    </a>
	///   </description>
	///  </item>
	/// </list>
	/// </para>
	/// </remarks>
	/// <example>
	/// <code><![CDATA[
	/// var data = new ObservableCollectionEx<XXX>();
	/// ]]></code>
	/// </example>
	public class ObservableCollectionEx<T> : ObservableCollection<T>
	{
		// Override the event so this class can access it
		/// <summary>要素変更時のイベントをオーバーライド
		/// </summary>
		public override event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;

		/// <summary>要素変更時のイベント
		/// </summary>
		/// <param name="e">変更の内容</param>
		protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			// Be nice - use BlockReentrancy like MSDN said
			using (this.BlockReentrancy()) {
				System.Collections.Specialized.NotifyCollectionChangedEventHandler eventHandler = CollectionChanged;
				if (eventHandler == null)
					return;

				Delegate[] delegates = eventHandler.GetInvocationList();
				// Walk thru invocation list
				foreach (System.Collections.Specialized.NotifyCollectionChangedEventHandler handler in delegates) {
					DispatcherObject dispatcherObject = handler.Target as DispatcherObject;
					// If the subscriber is a DispatcherObject and different thread
					if (dispatcherObject != null && dispatcherObject.CheckAccess() == false) {
						// Invoke handler in the target dispatcher's thread
						dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, handler, this, e);
					}
					else // Execute handler as is
						handler(this, e);
				}
			}
		}
	}
}
