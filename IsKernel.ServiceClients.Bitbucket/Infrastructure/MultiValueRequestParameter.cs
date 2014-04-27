using System;
using System.Collections.Generic;

namespace IsKernel.ServiceClients.Bitbucket.Infrastructure
{
	public class MultiValueRequestParameter<T> : RequestParameterBase
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
					if(typeof(T).BaseType.IsGenericType && typeof(T).BaseType.GetGenericTypeDefinition() == typeof(ClassEnumBase<>))
					{
						var newElement = (dynamic)(element);
						parameterValue += newElement.Value + "|";	
					}
					else
					{
						parameterValue += element + "|";
					}
				}
				parameterValue = parameterValue.Substring(0, parameterValue.Length - 1);
				return parameterValue;
			}			
		}
	}
}
