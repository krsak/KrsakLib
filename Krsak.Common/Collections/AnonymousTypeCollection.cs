using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krsak.Common.Collections
{
	/// <summary>匿名型のコレクションを作成する
	/// </summary>
	/// <remarks>
	/// 参考文献
	/// <list type="bullet">
	///  <item>
	///   <term>匿名型の Generic リスト - ++C++; // 管理人の日記</term>
	///   <description>
	///    <a href="http://d.hatena.ne.jp/ufcpp/20071207/1197030259">
	///    http://d.hatena.ne.jp/ufcpp/20071207/1197030259
	///    </a>
	///   </description>
	///  </item>
	/// </list>
	/// </remarks>
	public static class AnonymousTypeCollection
	{
		/// <summary>任意の型の<see cref="System.Collections.Generic.List{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_list = AnonymousTypeCollection.CreateList(new {Name = "", Age = ""});
		/// anonymous_list.Add(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static List<T> CreateList<T>(T val) { return new List<T>(); }
		/// <summary>任意の型の<see cref="System.Collections.Generic.LinkedList{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_list = AnonymousTypeCollection.CreateLinkedList(new {Name = "", Age = ""});
		/// anonymous_list.Add(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static LinkedList<T> CreateLinkedList<T>(T val) { return new LinkedList<T>(); }
		/// <summary>任意の型の<see cref="System.Collections.Generic.SortedList{TKey, TValue}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="TKey">キーの型</typeparam>
		/// <typeparam name="TValue">要素の型</typeparam>
		/// <param name="key">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_list = AnonymousTypeCollection.CreateSortedList("", new {Name = "", Age = ""});
		/// anonymous_list.Add("Inoue", new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static SortedList<TKey, TValue> CreateSortedList<TKey, TValue>(TKey key, TValue val) { return new SortedList<TKey, TValue>(); }

		/// <summary>任意の型の<see cref="System.Collections.Generic.HashSet{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_hash = AnonymousTypeCollection.CreateSortedList(new {Name = "", Age = ""});
		/// anonymous_hash.Add(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static HashSet<T> CreateHashSet<T>(T val) { return new HashSet<T>(); }
		/// <summary>任意の型の<see cref="System.Collections.Generic.SortedSet{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_set = AnonymousTypeCollection.CreateSortedSet(new {Name = "", Age = ""});
		/// anonymous_set.Add(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static SortedSet<T> CreateSortedSet<T>(T val) { return new SortedSet<T>(); }

		/// <summary>任意の型の<see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="TKey">キーの型</typeparam>
		/// <typeparam name="TValue">要素の型</typeparam>
		/// <param name="key">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_dic = AnonymousTypeCollection.CreateDictionary("", new {Name = "", Age = ""});
		/// anonymous_dic.Add("Inoue", new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static Dictionary<TKey, TValue> CreateDictionary<TKey, TValue>(TKey key, TValue val) { return new Dictionary<TKey, TValue>(); }
		/// <summary>任意の型の<see cref="System.Collections.Generic.SortedDictionary{TKey, TValue}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="TKey">キーの型</typeparam>
		/// <typeparam name="TValue">要素の型</typeparam>
		/// <param name="key">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_dic = AnonymousTypeCollection.CreateSortedDictionary("", new {Name = "", Age = ""});
		/// anonymous_dic.Add("Inoue", new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static SortedDictionary<TKey, TValue> CreateSortedDictionary<TKey, TValue>(TKey key, TValue val) { return new SortedDictionary<TKey, TValue>(); }

		/// <summary>任意の型の<see cref="System.Collections.Generic.Queue{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_queue = AnonymousTypeCollection.CreateQueue(new {Name = "", Age = ""});
		/// anonymous_queue.Enqueue(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static Queue<T> CreateQueue<T>(T val) { return new Queue<T>(); }
		/// <summary>任意の型の<see cref="System.Collections.Generic.Stack{T}"/>を生成する。匿名型コレクション生成のために用意した
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="val">任意の値（型が特定できれば良いので値は何でもいい）</param>
		/// <returns>任意の型のコレクション</returns>
		/// <example>
		/// <code><![CDATA[
		/// var anonymous_stack = AnonymousTypeCollection.CreateStack(new {Name = "", Age = ""});
		/// anonymous_stack.Push(new {Name = "Inoue", Age = "17"});
		/// ]]></code>
		/// </example>
		public static Stack<T> CreateStack<T>(T val) { return new Stack<T>(); }
	}
}
