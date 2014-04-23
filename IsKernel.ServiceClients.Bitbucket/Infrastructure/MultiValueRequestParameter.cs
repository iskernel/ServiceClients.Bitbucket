using System;
using System.Collections.Generic;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public class MultiValueRequestParameter<T> : RequestParameterBase where T : PrivateValueModel<string>
	{		
		public MultiValueRequestParameter(string name, IEnumerable<T> values) : base(name)
		{
			Values = values;
		}
		
		public IEnumerable<T> Values {get;set;}
		
		public string ParameterValue
		{
			get
			{
				var parameterValue = string.Empty;
				foreach (var element in Values) 
				{
					parameterValue += element.Value + "|";
				}
				parameterValue = parameterValue.Substring(0, parameterValue.Length - 1);
				return parameterValue;
			}			
		}
	}
}
