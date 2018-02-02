using System;

namespace Common
{
	///<summary>
	/// Расширения для монадических цепочек
	///</summary>
	public static class ChainExt
	{
		///<summary>
		/// Возвращает <paramref name="eval"/> или значение по умолчанию для <typeparamref name="TResult"/>, если <paramref name="o"/> == null.
		///</summary>
		///<returns><paramref name="eval"/> или значение по умолчанию для <typeparamref name="TResult"/>, если <paramref name="o"/> == null</returns>
		public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> eval)
			where TInput : class
		{
			return o == null ? default(TResult) : eval(o);
		}

		///<summary>
		/// Возвращает <paramref name="eval"/> или <paramref name="failureValue"/>, если <paramref name="o"/> == null.
		///</summary>
		///<returns><paramref name="eval"/> или <paramref name="failureValue"/>, если <paramref name="o"/> == null</returns>
		public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> eval, TResult failureValue)
			where TInput : class
		{
			return o == null ? failureValue : eval(o);
		}

		///<summary>
		/// Возвращает <paramref name="o"/>, если <paramref name="o"/> != null и выполняется условие <paramref name="eval"/>. Иначе - null.
		///</summary>
		public static TInput If<TInput>(this TInput o, Func<TInput, bool> eval)
			where TInput : class
		{
			if (o == null)
				return null;
			return eval(o) ? o : null;
		}

		///<summary>
		/// Выполняет делегат <paramref name="action"/> в цепочке.
		///</summary>
		///<returns><paramref name="o"/></returns>
		public static TInput Do<TInput>(this TInput o, Action<TInput> action)
			where TInput : class
		{
			if (o == null)
				return null;
			action(o);
			return o;
		}
	}
}