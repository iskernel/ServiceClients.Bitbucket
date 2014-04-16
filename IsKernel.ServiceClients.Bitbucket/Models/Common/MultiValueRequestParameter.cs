using System;
using System.Collections.Generic;

namespace IsKernel.ServiceClients.Bitbucket.Models.Common
{
	public class MultiValueRequestParameter<T> : RequestParameterBase
	{		
		public MultiValueRequestParameter(string name, IEnumerable<T> values) : base(name)
		{
			Values = values;
		}
		
		public IEnumerable<T> Values {get;set;}
	}
}
