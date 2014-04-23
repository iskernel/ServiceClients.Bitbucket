using System;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public class RequestParameter<T> : RequestParameterBase
	{
		public RequestParameter(string name, T value) : base(name)
		{
			Value = value;
		}
				
		public T Value {get;set;}
	}
}
