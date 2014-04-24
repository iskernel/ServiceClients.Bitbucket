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
		
		public Tuple<string,string> ToTuple()
		{
			var tuple = new Tuple<string,string>(Name, Value.ToString());
			return tuple;
		}
	}
}
