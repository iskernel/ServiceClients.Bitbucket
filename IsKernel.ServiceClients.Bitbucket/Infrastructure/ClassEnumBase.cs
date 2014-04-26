using System;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public abstract class ClassEnumBase<T> where T : class
	{
		public T Value { get; private set;}
		
		protected ClassEnumBase(T value)
		{
			Value = value;
		}
	}
}
