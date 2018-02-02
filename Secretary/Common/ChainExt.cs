using System;

namespace Common
{
	///<summary>
	/// ���������� ��� ������������ �������
	///</summary>
	public static class ChainExt
	{
		///<summary>
		/// ���������� <paramref name="eval"/> ��� �������� �� ��������� ��� <typeparamref name="TResult"/>, ���� <paramref name="o"/> == null.
		///</summary>
		///<returns><paramref name="eval"/> ��� �������� �� ��������� ��� <typeparamref name="TResult"/>, ���� <paramref name="o"/> == null</returns>
		public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> eval)
			where TInput : class
		{
			return o == null ? default(TResult) : eval(o);
		}

		///<summary>
		/// ���������� <paramref name="eval"/> ��� <paramref name="failureValue"/>, ���� <paramref name="o"/> == null.
		///</summary>
		///<returns><paramref name="eval"/> ��� <paramref name="failureValue"/>, ���� <paramref name="o"/> == null</returns>
		public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> eval, TResult failureValue)
			where TInput : class
		{
			return o == null ? failureValue : eval(o);
		}

		///<summary>
		/// ���������� <paramref name="o"/>, ���� <paramref name="o"/> != null � ����������� ������� <paramref name="eval"/>. ����� - null.
		///</summary>
		public static TInput If<TInput>(this TInput o, Func<TInput, bool> eval)
			where TInput : class
		{
			if (o == null)
				return null;
			return eval(o) ? o : null;
		}

		///<summary>
		/// ��������� ������� <paramref name="action"/> � �������.
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