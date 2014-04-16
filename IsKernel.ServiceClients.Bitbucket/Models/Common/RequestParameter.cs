using System;

namespace IsKernel.ServiceClients.Bitbucket.Models.Common
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
