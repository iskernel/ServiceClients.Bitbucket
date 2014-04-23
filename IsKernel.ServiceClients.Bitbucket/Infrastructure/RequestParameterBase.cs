using System;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public class RequestParameterBase
	{
		public RequestParameterBase(string name)
		{
			Name = name;
		}
		
		public string Name {get; private set;}
	}
}
