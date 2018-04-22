using System;

namespace Khairia.DependencyInjection
{
	public class DependencyInjectionContainer
	{
		private readonly Func<Type, object> _getter;

		public DependencyInjectionContainer(Func<Type, object> getter)
		{
			_getter = getter;
		}

		public object GetInstance(Type type)
		{
			return _getter(type);
		}

		public T GetInstance<T>()
		{
			return (T) GetInstance(typeof(T));
		}
	}
}