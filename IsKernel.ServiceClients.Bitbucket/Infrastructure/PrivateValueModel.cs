using System;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public abstract class PrivateValueModel<T> where T : class
	{
		public T Value { get; private set;}
		
		protected PrivateValueModel(T value)
		{
			Value = value;
		}
	}
}
